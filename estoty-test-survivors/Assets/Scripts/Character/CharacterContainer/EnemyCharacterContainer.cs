using System;
using UnityEngine;

namespace estoty_test
{
    public interface IEnemyCharacterPoolableContainer : IPooledItem<IEnemyCharacterPoolableContainer>
    {
        GameObject gameObject { get; }
        BaseEntity GetEntity();
    }

    public class EnemyCharacterContainer : CharacterContainer, IEnemyCharacterPoolableContainer
    {
        private HealthComponent _healthComponent;

        public IEnemyCharacterPoolableContainer Item => this;
        public IPool<IEnemyCharacterPoolableContainer> Pool { get; set; }

        private void Awake()
        {
            if (character.TryGetComponent<HealthComponent>(out _healthComponent))
            {
                if (Pool == null)
                    _healthComponent.OnDeath += DestroyEnemy;
                else
                    _healthComponent.OnDeath += ReturnToPool;
            }
        }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);

            if (_healthComponent != null)
            {
                _healthComponent.HealthData.CurrentHP = _healthComponent.HealthData.MaxHP;
            }

            if (character.TryGetComponent<ChaseTransformMovementComponent>(out var chaseComponent))
            {
                chaseComponent.Target = null;
            }

            Pool.Add(Item);
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _healthComponent.OnDeath -= DestroyEnemy;

            if (_healthComponent != null)
                _healthComponent.OnDeath -= ReturnToPool;
        }
    }
}
