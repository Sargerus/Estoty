using System;
using System.Collections.Generic;

namespace estoty_test
{
    public sealed class HandsWeaponView : WeaponView
    {
        public Collider2DOnTriggerStay2DCheck CollideCheck;
        public MeleeWeaponData WeaponData;

        private DateTime _lastTimeAttacked = DateTime.MinValue;
        private HashSet<DamagableComponent> _wasDamagedThisRound = new();

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
            CollideCheck.EnableComponent(false);
            CollideCheck.OnDamage += OnDamage;
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
            _wasDamagedThisRound.Clear();
            base.Attack();
            CollideCheck.EnableComponent(true);
            _lastTimeAttacked = DateTime.UtcNow;
        }

        private void OnDamage(DamagableComponent component)
        {
            if (_wasDamagedThisRound.Contains(component))
                return;

            component.TakeDamage(WeaponData.Damage);
            _wasDamagedThisRound.Add(component);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            _wasDamagedThisRound.Clear();

            if (CollideCheck != null)
            {
                CollideCheck.OnDamage -= OnDamage;
                CollideCheck.Dispose();
            }
        }
    }
}
