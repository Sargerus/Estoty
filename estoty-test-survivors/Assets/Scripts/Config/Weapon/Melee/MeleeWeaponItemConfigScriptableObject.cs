using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[Weapons]/Melee_WeaponItemConfig", fileName = "new MeleeWeaponConfig")]
    public class MeleeWeaponItemConfigScriptableObject : ScriptableObject
    {
        public string Id;
        public float AttackRate;
        public float AttackSpeed;
        public float AttackRadius;
        public float Damage;

        public MeleeWeaponView View;
    }
}
