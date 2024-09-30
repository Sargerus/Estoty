using System;
using System.Collections.Generic;
using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[Pools]/BonusPool/BonusPoolItems", fileName = "new BonusPoolItems")]
    public class BonusPoolItemsScriptableObject : ScriptableObject
    {
        public List<BonusPoolItemInfo> BonusItems;
    }

    [Serializable]
    public class BonusPoolItemInfo
    {
        public string Key;
        public BaseBonusComponent Bonus;
        public int DefaultPoolItemsCount;
    }
}
