using System;
using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Animator))]
    public abstract class WeaponView : MonoBehaviour
    {
        public DamagableComponent CurrentTarget;
        public Transform ColliderParent;

        [Space(20)]
        public ColliderInRangeCheck EnemyInRangeCheck;

        protected Animator _animator;

        protected abstract bool CanAttack { get; }

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            EnemyInRangeCheck.transform.SetParent(ColliderParent);
        }

        public virtual void Attack()
        {
            _animator.SetTrigger("attack");
        }

        protected virtual bool IsEnemyInRange()
        {
            if (EnemyInRangeCheck == null)
                return false;

            bool result = EnemyInRangeCheck.IsEnemyInRange(out var damagableComponent);
            CurrentTarget = damagableComponent;

            return result;
        }

        protected virtual void OnDestroy()
        {
            Destroy(EnemyInRangeCheck.gameObject);
        }
    }
}
