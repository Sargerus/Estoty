using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace estoty_test
{
    public interface IBonusSpawner
    {
        void SpawnBonus(string key, Vector3 spawnPos, float dropRadius = 2f);
        void SpawnBonus(string key, Vector3 spawnPos, int stackCount, int totalValue, float dropRadius = 2f);
    }

    public class BonusSpawner : MonoBehaviour, IBonusSpawner
    {
        [SerializeField] private BonusPool bonusPoolPrefab;

        private BonusPoolItemsScriptableObject _bonusItemsSettings;
        private DiContainer _diContainer;

        private Dictionary<string, BonusPool> _bonusKeyTransform = new();

        [Inject]
        private void Construct(BonusPoolItemsScriptableObject bonusItemsSettings, DiContainer diContainer)
        {
            _bonusItemsSettings = bonusItemsSettings;
            _diContainer = diContainer;
        }

        private void Start()
        {
            foreach (var bonus in _bonusItemsSettings.BonusItems)
            {
                BonusPool bonusPool = _diContainer.InstantiatePrefabForComponent<BonusPool>(bonusPoolPrefab, transform);
                bonusPool.Initialize(bonus.Bonus, bonus.DefaultPoolItemsCount, _diContainer);
                bonusPool.name = bonus.Key;

                _bonusKeyTransform.Add(bonus.Key, bonusPool);
            }
        }

        public void SpawnBonus(string key, Vector3 spawnPos, float dropRadius = 2f)
        {
            if (!_bonusKeyTransform.TryGetValue(key, out BonusPool bonusPool))
                return;

            Vector3 pos = new(spawnPos.x + UnityEngine.Random.Range(-dropRadius, dropRadius),
                spawnPos.y + UnityEngine.Random.Range(-dropRadius, dropRadius),
                0f);

            IPooledItem<IBonusPoolable> bonus = bonusPool.Get();
            bonus.Item.gameObject.transform.position = pos;
            bonus.Item.gameObject.SetActive(true);
        }

        public void SpawnBonus(string key, Vector3 spawnPos, int stackCount, int totalValue, float dropRadius = 2f)
        {
            if (!_bonusKeyTransform.TryGetValue(key, out BonusPool bonusPool))
                return;

            var value = totalValue / stackCount;

            for (int i = 0; i < stackCount; i++)
            {
                Vector3 pos = new(spawnPos.x + UnityEngine.Random.Range(-dropRadius, dropRadius),
                    spawnPos.y + UnityEngine.Random.Range(-dropRadius, dropRadius),
                    0f);

                IPooledItem<IBonusPoolable> bonus = bonusPool.Get();
                bonus.Item.gameObject.transform.position = pos;

                if (!bonus.Item.gameObject.TryGetComponent<CountComponent>(out var countComponent))
                {
                    countComponent = bonus.Item.gameObject.AddComponent<CountComponent>();
                }

                countComponent.Count = value;
                bonus.Item.gameObject.SetActive(true);
            }
        }
    }
}
