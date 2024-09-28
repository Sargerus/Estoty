using System.Collections.Generic;
using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Collider2D))]
    public class ShovelInRangeCheck : BaseEnemyInRangeCheck
    {
        [SerializeField] private List<Collider2D> _colliders;
        private List<Collider2D> _overlapResult = new();

        private void Update()
        {
            transform.rotation = Quaternion.identity;
        }

        public override bool IsEnemyInRange(out DamagableComponent damagableComponent)
        {
            damagableComponent = null;

            ContactFilter2D filter = new();
            filter.NoFilter();
            List<DamagableComponent> dc = new();

            foreach (var collider in _colliders)
            {
                collider.OverlapCollider(filter, _overlapResult);

                if (_overlapResult.Count <= 0)
                    continue;

                foreach (var res in _overlapResult)
                {
                    if (res.TryGetComponent<DamagableComponent>(out var dd))
                        dc.Add(dd);
                }
            }

            float maxDistance = float.MaxValue;

            foreach(var component in dc)
            {
                float distance = Vector2.Distance(transform.position, component.transform.position);
                if(distance < maxDistance)
                {
                    damagableComponent = component;
                    maxDistance = distance;
                }
            }

            return damagableComponent != null;
        }
    }
}
