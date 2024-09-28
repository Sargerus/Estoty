using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace estoty_test
{
    public class PlayerCharacter : BaseCharacter
    {
        [SerializeField] private Transform weaponParent;
        [SerializeField] private Transform weaponCenter;
        [SerializeField] private Transform weaponColliderParent;
        [SerializeField] private Transform playerBody;
        [SerializeField] private RotateToWeaponTargetComponent rotateToWeaponTargetComponent;
        [SerializeField] private PlayerAnimatorController _playersAnimator;

        private List<BaseComponent> _components = new();

        private void Awake()
        {
            _components.AddRange(GetComponents<BaseComponent>());
        }

        public void ReplaceWeapon(WeaponBonusScriptableObject meleeData)
        {
            DropAllWeapon();

            var weaponComponent = gameObject.AddComponent<WeaponComponent>();
            weaponComponent.CreateWeapon(meleeData.View, weaponParent, weaponCenter, weaponColliderParent);
            _components.Add(weaponComponent);

            if (rotateToWeaponTargetComponent)
            {
                rotateToWeaponTargetComponent.Target = playerBody;
                rotateToWeaponTargetComponent.WeaponComponent = weaponComponent;
            }
        }

        private void DropAllWeapon()
        {
            List<BaseComponent> toDelete = new();

            foreach (var component in _components.OfType<WeaponComponent>())
            {
                component.Dispose();
                toDelete.Add(component);
            }

            foreach(var delete in toDelete)
                _components.Remove(delete);
        }

        public void ApplyBonus(BaseBonusScriptableObject bonusData)
        {
            if (bonusData is WeaponBonusScriptableObject meleeData)
            {
                ReplaceWeapon(meleeData);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BonusBehaviour bb))
            {
                ApplyBonus(bb.BonusData);
                Destroy(collision.gameObject);
            }
        }
    }
}