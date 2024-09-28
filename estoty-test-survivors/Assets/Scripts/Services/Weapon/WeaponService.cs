using System.Linq;

namespace estoty_test
{
    public interface IWeaponService
    {
        MeleeWeaponItemConfigScriptableObject GetMeleeWeaponById(string id);
        RangeWeaponItemConfigScriptableObject GetRangeWeaponById(string id);
    }

    internal class WeaponService : IWeaponService
    {
        private WeaponsContainerScriptableObject _weapons;

        public WeaponService(WeaponsContainerScriptableObject weapons)
        {
            _weapons = weapons;
        }

        public MeleeWeaponItemConfigScriptableObject GetMeleeWeaponById(string id)
        {
            return _weapons.MeleeWeapons.FirstOrDefault(g => g.Id.Equals(id));
        }

        public RangeWeaponItemConfigScriptableObject GetRangeWeaponById(string id)
        {
            return _weapons.RangeWeapons.FirstOrDefault(g => g.Id.Equals(id));
        }
    }
}
