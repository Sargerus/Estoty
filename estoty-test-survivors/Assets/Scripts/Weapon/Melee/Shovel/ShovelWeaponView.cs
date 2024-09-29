using System;
using System.Collections.Generic;

namespace estoty_test
{
    public sealed class ShovelWeaponView : WeaponView
    {
        public Collider2DOnTriggerEnter2DCheck CollideCheck;
        public MeleeWeaponData WeaponData;

        private HashSet<DamagableComponent> _wasDamagedThisRound = new();
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

        //called for attack animation
        public void HalfAnimationPassed()
        {
            _wasDamagedThisRound.Clear();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if(CollideCheck != null)
            {
                CollideCheck.OnDamage -= OnDamage;
                CollideCheck.Dispose();
            }
        }
    }
}
