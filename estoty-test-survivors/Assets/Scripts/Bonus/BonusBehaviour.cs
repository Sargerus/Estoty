using UnityEngine;

namespace estoty_test
{
    public enum BonusType
    {
        None = 0,
        Weapon = 10,
        Item = 20
    }

    public class BonusBehaviour : MonoBehaviour
    {
        public BonusType BonusType;
        public string Id;
    }
}
