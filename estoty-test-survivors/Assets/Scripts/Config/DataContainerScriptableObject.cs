using System.Collections.Generic;
using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[DATA]/Container", fileName = "DataContainer")]
    public class DataContainerScriptableObject : ScriptableObject
    {
        public List<BaseDataScriptableObject> DataModules;
    }
}
