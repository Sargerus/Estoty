using System;
using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Animator))]
    public abstract class WeaponView : MonoBehaviour
    {
        [SerializeField] protected BaseEnemyInRangeCheck enemyInRangeCheck;

        protected Animator _animator;

        public DamagableComponent CurrentTarget;
        public Transform ColliderParent;

        protected abstract bool CanAttack { get; }

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            enemyInRangeCheck.transform.SetParent(ColliderParent);
        }

        public virtual void Attack()
        {
            _animator.SetTrigger("attack");
        }

        protected virtual bool IsEnemyInRange()
        {
            bool result = enemyInRangeCheck.IsEnemyInRange(out var damagableComponent);
            CurrentTarget = damagableComponent;

            return result;
        }

        protected virtual void OnDestroy()
        {
            Destroy(enemyInRangeCheck.gameObject);
        }
    }
}
