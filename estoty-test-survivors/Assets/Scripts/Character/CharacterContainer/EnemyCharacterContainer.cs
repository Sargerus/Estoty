using UnityEngine;

namespace estoty_test
{
    public interface IEnemyCharacterPoolableContainer : IPooledItem<IEnemyCharacterPoolableContainer>
    {
        GameObject gameObject { get; }
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

        private void OnDestroy()
        {
            if (_healthComponent != null)
                _healthComponent.OnDeath -= ReturnToPool;
        }
    }
}
