using System;
using System.Collections.Generic;
using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[PlayerLevel]/PlayerLevelConfig", fileName = "new PlayerLevelConfig")]
    public class LevelConfigScriptableObject : ScriptableObject
    {
        public List<LevelInfo> Levels;
    }

    [Serializable]
    public class LevelInfo
    {
        public float ExperienceRequired;
    }
}
