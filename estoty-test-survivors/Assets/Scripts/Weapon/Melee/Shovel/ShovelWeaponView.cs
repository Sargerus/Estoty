using UnityEngine;

namespace estoty_test
{
    public sealed class ShovelWeaponView : MeleeWeaponView
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

            if (!IsEnemyInRange())
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

        private bool IsEnemyInRange()
        {
            bool result = enemyInRangeCheck.IsEnemyInRange(out var damagableComponent);
            CurrentTarget = damagableComponent;

            return result;
        }
    }
}
