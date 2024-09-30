using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemiesPool poolPrefab;

        private LevelPoolsSettingsScriptableObject _settings;
        private ILevelMapService _levelMapService;
        private DiContainer _diContainer;

        private List<EnemiesPool> _pools = new();

        [Inject]
        private void Construct(LevelPoolsSettingsScriptableObject settings, ILevelMapService levelMapService, DiContainer diContainer)
        {
            _settings = settings;
            _levelMapService = levelMapService;
            _diContainer = diContainer;
        }

        public void StartSpawn()
        {
            Setup();
            
            for(int i = 0; i < _pools.Count; i++) 
            {
                StartCoroutine(ProcessPool(_pools[i], _settings.Pools[i].SpawnTimer));
            }
        }

        public void StopSpawn()
        {
            StopAllCoroutines();
        }

        private void Setup()
        {
            StopAllCoroutines();

            _pools.ForEach(g => Destroy(g.gameObject));
            _pools.Clear();

            foreach (var pool in _settings.Pools)
            {
                EnemiesPool go = _diContainer.InstantiatePrefabForComponent<EnemiesPool>(poolPrefab, transform);
                go.Initialize(pool.Prefab, 10, _diContainer);
                go.name = pool.Prefab.name;
                _pools.Add(go);
            }
        }

        private IEnumerator ProcessPool(EnemiesPool pool, float spawmRate)
        {
            WaitForSeconds wfs = new(spawmRate);
            Vector3 spawnPos = Vector3.zero;

            while (gameObject != null)
            {
                while (!_levelMapService.TryGetSpawnPosition(out spawnPos))
                    yield return null;

                var newEnemy = pool.Get();

                //add chase transform

                newEnemy.Item.gameObject.transform.position = spawnPos;
                newEnemy.Item.gameObject.SetActive(true);
                yield return wfs;
            }
        }
    }
}
