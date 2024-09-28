using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Collider2D))]
    public class ShovelInRangeCheck : BaseEnemyInRangeCheck
    {
        private Collider2D _collider;
        private List<Collider2D> _overlapResult = new();

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        public override bool IsEnemyInRange()
        {
            ContactFilter2D filter = new ContactFilter2D();
            filter.NoFilter();
            _collider.OverlapCollider(filter, _overlapResult);

            return _overlapResult.Count > 0 && _overlapResult.Any(g => g.TryGetComponent<DamagableComponent>(out _));
        }
    }
}
