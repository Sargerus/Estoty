using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace estoty_test
{
    [Serializable]
    public class StackInfo
    {
        public BaseBonusComponent BonusView;
        public int StacksCount;
        public int BonusCount;
    }

    public class DropOnDeathComponent : BaseComponent
    {
        public HealthComponent HealthComponent;
        public List<BaseBonusComponent> UniqueDrop;
        public List<StackInfo> StackDrop;
        public float DropRadius;

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
            foreach (var unique in UniqueDrop)
            {
                Vector3 pos = new(transform.position.x + UnityEngine.Random.Range(-DropRadius, DropRadius),
                    transform.position.y + UnityEngine.Random.Range(-DropRadius, DropRadius),
                    0f);

                Instantiate(unique, pos, Quaternion.identity);
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
