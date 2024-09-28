using System.Collections.Generic;
using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[Weapons]/WeaponsContainer", fileName = "new WeaponsContainer")]
    public class WeaponsContainerScriptableObject : ScriptableObject
    {
        public List<MeleeWeaponItemConfigScriptableObject> MeleeWeapons;
        public List<RangeWeaponItemConfigScriptableObject> RangeWeapons;
    }
}
