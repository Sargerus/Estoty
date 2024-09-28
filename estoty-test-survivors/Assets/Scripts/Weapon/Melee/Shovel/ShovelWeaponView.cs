using System;
using UnityEngine;

namespace estoty_test
{
    public sealed class ShovelWeaponView : WeaponView
    {
        [SerializeField] private ShovelDamageCheck shovelDamageCheck;

        public MeleeWeaponData WeaponData;

        private DateTime _lastTimeAttacked = DateTime.MinValue;

        protected override bool CanAttack
        {
            get
            {
                DateTime nextTimeAttack = _lastTimeAttacked.AddSeconds(1 / WeaponData.AttackRate);
                TimeSpan ts = DateTime.UtcNow - nextTimeAttack;

                return ts.TotalMilliseconds >= 0;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            shovelDamageCheck.OnDamage += OnDamage;
        }

        private void Update()
        {
            if (!IsEnemyInRange())
                return;

            if (!CanAttack)
                return;

            Attack();
        }

        public override void Attack()
        {
            base.Attack();
            _lastTimeAttacked = DateTime.UtcNow;
        }

        private void OnDamage(DamagableComponent component)
        {
            component.TakeDamage(WeaponData.Damage);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            shovelDamageCheck.OnDamage -= OnDamage;
        }
    }
}
