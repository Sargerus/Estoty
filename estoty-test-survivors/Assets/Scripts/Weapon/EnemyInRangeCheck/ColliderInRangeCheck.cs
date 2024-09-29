using System.Collections.Generic;
using UnityEngine;

namespace estoty_test
{
    public class ColliderInRangeCheck : BaseComponent
    {
        public LayerMask TargetLayerMask;

        [Space(20)]
        public List<Collider2D> _colliders;

        private List<Collider2D> _overlapResult = new();

        public bool IsEnemyInRange(out DamagableComponent damagableComponent)
        {
            damagableComponent = null;

            ContactFilter2D filter = new()
            {
                useTriggers = true
            };
            filter.SetLayerMask(TargetLayerMask);
            List<DamagableComponent> dc = new();

            foreach (var collider in _colliders)
            {
               int count =  Physics2D.OverlapCollider(collider, filter, _overlapResult);

                if (count <= 0)
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

        public override void Dispose()
        {
            Destroy(gameObject);
        }
    }
}
