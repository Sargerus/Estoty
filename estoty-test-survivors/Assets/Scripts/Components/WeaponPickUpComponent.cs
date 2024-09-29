using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Collider2D))]
    public class WeaponPickUpComponent : BaseComponent
    {
        public HolsterComponent Holster;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BonusBehaviour bb))
            {
                if (TryApplyBonus(bb.BonusData))
                    Destroy(collision.gameObject);
            }
        }

        private bool TryApplyBonus(BaseBonusScriptableObject bonusData)
        {
            if (bonusData is WeaponBonusScriptableObject weaponData)
            {
                if(Holster == null)
                {
                    return false;
                }

                Holster.ReplaceWeapon(weaponData);
            }

            return true;
        }

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
