using System;
using UnityEngine;

namespace estoty_test
{
    public class ShovelWeaponView : MeleeWeaponView
    {
        [SerializeField] private BaseEnemyInRangeCheck enemyInRangeCheck;
        [SerializeField] private ShovelDamageCheck shovelDamageCheck;

        protected override void Awake()
        {
            base.Awake();
            shovelDamageCheck.OnDamage += OnDamage;
        }

        private void Update()
        {
            if (!CanMeleeAttack)
                return;

            if(!enemyInRangeCheck.IsEnemyInRange()) 
                return;

            Attack();
        }

        private void OnDamage(DamagableComponent component)
        {
            component.TakeDamage(WeaponData.Damage);
            OnAttack?.Invoke(component);
        }

        private void OnDestroy()
        {
            shovelDamageCheck.OnDamage -= OnDamage;
        }
    }
}
