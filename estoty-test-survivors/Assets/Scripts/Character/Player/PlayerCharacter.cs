using System;
using Zenject;

namespace estoty_test
{
    public interface IMeleeWeaponAttackable
    {
        bool CanMeleeAttack { get; }
        void AttackMelee();
        void HitMeleeTarget();
    }

    public class PlayerCharacter : BaseCharacter, IMeleeWeaponAttackable
    {
        public MeleeWeaponData MeleeWeaponData;

        private IWeaponService _weaponService;

        private PlayerView _playerView;

        public bool HasMeleeWeapon => MeleeWeaponData != null;
        public bool CanMeleeAttack => MeleeWeaponData != null && MeleeWeaponData.CanMeleeAttack;

        [Inject]
        public void Construct(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        public override void SetView(BaseView view)
        {
            base.SetView(view);
            _playerView = (PlayerView)view;
        }

        public void AttackMelee()
        {
            if (MeleeWeaponData.CanMeleeAttack)
            {
                MeleeWeaponData.LastTimeAttacked = DateTime.UtcNow;
                _playerView.PlayMeleeAttackAnimation();
            }
        }

        public void HitMeleeTarget()
        {
        }

        public void ReplaceWeapon(string id)
        {
            void EquipMeleeWeapon(MeleeWeaponItemConfigScriptableObject config)
            {
                MeleeWeaponData = new(config.Damage, config.AttackRadius, config.AttackRate, config.View, config.Id);
                _playerView.EquipMeleeWeapon();
            }

            void EquipRangeWeapon(RangeWeaponItemConfigScriptableObject config)
            {
                //MeleeWeaponData = new(config.Damage, config.AttackRadius, config.AttackRate, config.View, config.Id);
                //_playerView.EquipMeleeWeapon();
            }

            RangeWeaponItemConfigScriptableObject rangeConfig = null;
            MeleeWeaponItemConfigScriptableObject meleeConfig = _weaponService.GetMeleeWeaponById(id);

            if (meleeConfig != null)
            {
                EquipMeleeWeapon(meleeConfig);
            }
            else
            {
                rangeConfig = _weaponService.GetRangeWeaponById(id);
                if (rangeConfig != null)
                    EquipRangeWeapon(rangeConfig);
            }
        }
    }
}