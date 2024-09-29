using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Collider2D))]
    public class WeaponPickUpComponent : BaseComponent
    {
        public HolsterComponent Holster;
        public ExperienceComponent Experience;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var bonuses = collision.GetComponents<BaseBonusComponent>();

            foreach (var bonus in bonuses)
            {
                if (bonus is WeaponBonusComponent wbc)
                    if (TryEquipWeaponBonus(wbc))
                        Destroy(collision.gameObject);

                if (bonus is ExperienceBonusComponent ebc)
                    if (TryAddExperience(ebc))
                        Destroy(collision.gameObject);
            }
        }

        private bool TryEquipWeaponBonus(WeaponBonusComponent wbc)
        {
            if (Holster == null)
                return false;

            Holster.ReplaceWeapon(wbc.View);
            return true;
        }

        public bool TryAddExperience(ExperienceBonusComponent ebc)
        {
            if (Experience == null)
                return false;

            if (ebc.TryGetComponent<CountComponent>(out var cc))
            {
                Experience.AddExperience(cc.Count);
                return true;
            }

            return false;
        }

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
