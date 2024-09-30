using System;
using UnityEngine;

namespace estoty_test
{
    public sealed class PistolWeaponView : WeaponView
    {
        [SerializeField] private Transform bulletSpawn;

        public RangeWeaponData WeaponData;

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

        private void Update()
        {
            if (!IsEnemyInRange())
                return;

            LookAtTarget();

            if (!CanAttack)
                return;

            Attack();
        }

        private void LookAtTarget()
        {
            Vector3 direction = CurrentTarget.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - (direction.x < 0 ? 180 : 0);
            transform.localRotation = Quaternion.AngleAxis(angle, (direction.x < 0 ? -1 : 1) * Vector3.forward);
        }

        public override void Attack()
        {
            base.Attack();

            var bullet = Instantiate(WeaponData.BulletView, bulletSpawn.position, Quaternion.identity);
            bullet.Setup(WeaponData.Damage, 
                (CurrentTarget.transform.position - bulletSpawn.transform.position).normalized * WeaponData.BulletVelocity, 
                WeaponData.BulletMaxDistance, EnemyInRangeCheck.TargetLayerMask);
            bullet.gameObject.layer = gameObject.layer;
            bullet.Fly();

            _lastTimeAttacked = DateTime.UtcNow;
        }
    }
}
