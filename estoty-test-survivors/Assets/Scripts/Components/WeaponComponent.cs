using UnityEngine;

namespace estoty_test
{
    public class WeaponComponent : BaseWeaponComponent
    {
        public WeaponView View;

        public void CreateWeapon(WeaponView weaponPrefab, Transform weaponParent, 
            Transform weaponPosition, Transform weaponColliderParent, int layerForWeaponGO, LayerMask targetLayerMask)
        {
            View = Instantiate(weaponPrefab, weaponPosition.position, weaponPrefab.transform.localRotation, weaponParent);
            View.SetupWeapon(layerForWeaponGO, targetLayerMask);
            View.transform.localRotation = weaponPrefab.transform.localRotation;
            View.ColliderParent = weaponColliderParent;
        }

        private void Update()
        {
            if (View.CurrentTarget != null)
                CurrentTarget = View.CurrentTarget.transform;
            else
                CurrentTarget = null;
        }

        public override void Dispose()
        {
            Destroy(View.gameObject);
            Destroy(this);
        }
    }
}
