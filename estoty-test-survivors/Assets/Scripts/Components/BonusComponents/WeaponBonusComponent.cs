using UnityEngine;

namespace estoty_test
{
    public class WeaponBonusComponent : BaseBonusComponent
    {
        public override string Type => "weapon";

        public WeaponView View;
    }
}
