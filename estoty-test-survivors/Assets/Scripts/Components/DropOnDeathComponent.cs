using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace estoty_test
{
    [Serializable]
    public class StackInfo
    {
        public string BonusKey;
        public BaseBonusComponent BonusView;
        public int StacksCount;
        public int BonusCount;
    }

    [Serializable]
    public class UniqueInfo
    {
        public string BonusKey;
        public BaseBonusComponent BonusView;
    }

    public class DropOnDeathComponent : BaseComponent
    {
        public HealthComponent HealthComponent;
        public List<UniqueInfo> UniqueDrop;
        public List<StackInfo> StackDrop;
        public float DropRadius;
        public bool UsePool;

        private IBonusSpawner _bonusSpawner;

        [Inject]
        private void Construct([InjectOptional] IBonusSpawner bonusSpawner)
        {
            _bonusSpawner = bonusSpawner;
        }

        private void Start()
        {
            StartCoroutine(FindHealthComponent());
        }

        private IEnumerator FindHealthComponent()
        {
            while (HealthComponent == null)
            {
                if (TryGetComponent<HealthComponent>(out HealthComponent))
                    break;

                yield return null;
            }

            HealthComponent.OnDeath += OnDeath;
        }

        private void OnDeath()
        {
            if (UsePool)
            {
                if (_bonusSpawner == null)
                    return;

                foreach (var unique in UniqueDrop)
                {
                    _bonusSpawner.SpawnBonus(unique.BonusKey, transform.position, DropRadius);
                }

                foreach (var stack in StackDrop)
                {
                    _bonusSpawner.SpawnBonus(stack.BonusKey, transform.position, stack.StacksCount, stack.BonusCount, DropRadius);
                }
            }
            else
            {
                foreach (var unique in UniqueDrop)
                {
                    Vector3 pos = new(transform.position.x + UnityEngine.Random.Range(-DropRadius, DropRadius),
                        transform.position.y + UnityEngine.Random.Range(-DropRadius, DropRadius),
                        0f);

                    Instantiate(unique.BonusView, pos, Quaternion.identity);
                }

                foreach (var stack in StackDrop)
                {
                    var value = stack.BonusCount / stack.StacksCount;

                    for (int i = 0; i < stack.StacksCount; i++)
                    {
                        Vector3 pos = new(transform.position.x + UnityEngine.Random.Range(-DropRadius, DropRadius),
                            transform.position.y + UnityEngine.Random.Range(-DropRadius, DropRadius),
                            0f);

                        var stackView = Instantiate(stack.BonusView, pos, Quaternion.identity);
                        var countComponent = stackView.AddComponent<CountComponent>();
                        countComponent.Count = value;
                    }
                }
            }
        }

        public override void Dispose()
        {
            Destroy(this);
        }

        private void OnDestroy()
        {
            HealthComponent.OnDeath -= OnDeath;
        }
    }
}
