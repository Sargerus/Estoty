using System;
using UnityEngine;

namespace estoty_test
{
    public class MeleeWeaponComponent : BaseComponent
    {
        public MeleeWeaponData WeaponData;
        public MeleeWeaponView View;

        public bool CanMeleeAttack
        {
            get
            {
                DateTime nextTimeAttack = _lastTimeAttacked.AddSeconds(1 / WeaponData.AttackRate);
                TimeSpan ts = DateTime.UtcNow - nextTimeAttack;

                return ts.TotalMilliseconds >= 0;
            }
        }

        
        private DateTime _lastTimeAttacked = DateTime.MinValue;

        public void CreateWeapon(Transform weaponParent, Transform weaponPosition)
        {
            View = Instantiate(WeaponData.View, weaponPosition.position, Quaternion.identity, weaponParent);
        }

        private void Update()
        {
            if (View == null)
                return;

            Attack();
        }

        public void Attack()
        {
            if (!CanMeleeAttack)
                return;

            View.Attack();
            _lastTimeAttacked = DateTime.UtcNow;
        }

        public override void RemoveComponent()
        {
            Destroy(this);
        }
    }
}
