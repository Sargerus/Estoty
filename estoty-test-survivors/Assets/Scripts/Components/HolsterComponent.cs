using UnityEngine;

namespace estoty_test
{
    public class HolsterComponent : BaseComponent
    {
        public WeaponView CurrentWeapon;

        [Space(20)]
        public Transform WeaponParent;
        public Transform WeaponCenter;
        public Transform WeaponColliderParent;
        public int LayerForGameObject;
        public LayerMask TargetLayerMask;

        private WeaponComponent _currentWeaponComponent;

        public void ReplaceWeapon(WeaponView view)
        {
            DropAllWeapon();

            _currentWeaponComponent = gameObject.AddComponent<WeaponComponent>();
            _currentWeaponComponent.CreateWeapon(view, WeaponParent, WeaponCenter,
                WeaponColliderParent, LayerForGameObject, TargetLayerMask);
            CurrentWeapon = _currentWeaponComponent.View;
        }

        private void DropAllWeapon()
        {
            _currentWeaponComponent?.Dispose();
            if (CurrentWeapon != null)
                Destroy(CurrentWeapon.gameObject);
        }

        public override void Dispose()
        {
            Destroy(CurrentWeapon.gameObject);
            Destroy(this);
        }
    }
}
