using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace estoty_test
{
    public class PlayerCharacter : BaseCharacter
    {
        [SerializeField] private Transform meleeParent;
        [SerializeField] private Transform meleeCenter;
        [SerializeField] private PlayerAnimatorController _playersAnimator;

        private List<BaseComponent> _components = new();

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
            meleeComponent.CreateWeapon(meleeData.View, meleeParent, meleeCenter);
        }

        public void ApplyBonus(BaseBonusScriptableObject bonusData)
        {
            if (bonusData is MeleeWeaponBonusScriptableObject meleeData)
            {
                ReplaceMeleeWeapon(meleeData);
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