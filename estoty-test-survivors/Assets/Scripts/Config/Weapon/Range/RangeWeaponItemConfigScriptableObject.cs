using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[Weapons]/Range_WeaponItemConfig", fileName = "new RangeWeaponConfig")]
    public class RangeWeaponItemConfigScriptableObject : ScriptableObject
    {
        public string Id;
        public float AttackRate;
        public float AttackRadius;
        public float Damage;
        public float BulletType;

        public WeaponView View;
    }
}
