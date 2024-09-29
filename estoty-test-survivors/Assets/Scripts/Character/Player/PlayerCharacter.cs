using System.Collections.Generic;
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
    }
}