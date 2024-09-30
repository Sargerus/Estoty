using System.Collections.Generic;
using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName ="[Level]/LevelContainer", fileName = "new LevelContainer")]
    public class LevelContainerScriptableObject : ScriptableObject
    {
        public List<GameObject> Levels;
    }
}
