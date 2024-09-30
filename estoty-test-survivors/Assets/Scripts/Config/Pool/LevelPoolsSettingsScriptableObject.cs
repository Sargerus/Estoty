using System;
using System.Collections.Generic;
using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName ="[Pools]/EnemyPoolSettings", fileName = "new PoolSettings")]
    public class LevelPoolsSettingsScriptableObject : ScriptableObject
    {
        public List<PoolSettings> Pools;
    }

    [Serializable]
    public class PoolSettings
    {
        public EnemyCharacterContainer Prefab;
        public float SpawnTimer;
    }
}
