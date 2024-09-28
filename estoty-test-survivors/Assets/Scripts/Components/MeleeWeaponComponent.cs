using UnityEngine;

namespace estoty_test
{
    public class MeleeWeaponComponent : BaseComponent
    {
        public MeleeWeaponView View;

        public void CreateWeapon(MeleeWeaponView weaponPrefab, Transform weaponParent, Transform weaponPosition)
        {
            View = Instantiate(weaponPrefab, weaponPosition.position, Quaternion.identity, weaponParent);
        }

        public override void RemoveComponent()
        {
            Destroy(this);
        }
    }
}
