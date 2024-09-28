using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace estoty_test
{
    public class PlayerCharacter : BaseCharacter
    {
        [SerializeField] private PlayerView playerView;
        [SerializeField] private Transform meleeParent;
        [SerializeField] private Transform meleeCenter;

        private List<BaseComponent> _components = new();

        public override BaseView View { get => playerView; protected set => View = value; }

        private void Awake()
        {
            _components.AddRange(GetComponents<BaseComponent>());
        }

        public void ReplaceMeleeWeapon(MeleeWeaponBonusScriptableObject meleeData)
        {
            foreach (var melee in _components.OfType<MeleeWeaponComponent>())
            {
                melee.RemoveComponent();
            }
            
            var meleeComponent = gameObject.AddComponent<MeleeWeaponComponent>();
            meleeComponent.WeaponData = new MeleeWeaponData(meleeData.Data);
            meleeComponent.CreateWeapon(meleeParent, meleeCenter);
        }

        internal void ApplyBonus(BaseBonusScriptableObject bonusData)
        {
            if (bonusData is MeleeWeaponBonusScriptableObject meleeData)
            {
                ReplaceMeleeWeapon(meleeData);
            }
        }
    }
}