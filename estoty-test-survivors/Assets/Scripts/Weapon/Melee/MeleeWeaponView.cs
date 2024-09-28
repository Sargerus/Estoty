using System;
using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Animator))]
    public abstract class MeleeWeaponView : MonoBehaviour
    {
        protected Animator _animator;

        public MeleeWeaponData WeaponData;
        public Action<DamagableComponent> OnAttack;

        private DateTime _lastTimeAttacked = DateTime.MinValue;

        protected virtual bool CanMeleeAttack
        {
            get
            {
                DateTime nextTimeAttack = _lastTimeAttacked.AddSeconds(1 / WeaponData.AttackRate);
                TimeSpan ts = DateTime.UtcNow - nextTimeAttack;

                return ts.TotalMilliseconds >= 0;
            }
        }

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public virtual void Attack()
        {
            _lastTimeAttacked = DateTime.UtcNow;
            _animator.SetTrigger("attack");
        }
    }
}
