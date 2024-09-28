using UnityEngine;

namespace estoty_test
{
    public class ShovelWeaponView : MeleeWeaponView
    {
        [SerializeField] private BaseEnemyInRangeCheck enemyInRangeCheck;

        private void Update()
        {
            if (_attackLink == null)
                return;

            if (enemyInRangeCheck.IsEnemyInRange() && _attackLink.CanMeleeAttack)
            {
                _attackLink.AttackMelee();
            }
        }
    }
}
