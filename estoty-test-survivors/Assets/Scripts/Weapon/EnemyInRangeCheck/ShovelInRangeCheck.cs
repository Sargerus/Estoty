
using UnityEngine;

namespace estoty_test
{
    public class ShovelInRangeCheck : BaseEnemyInRangeCheck
    {
        [SerializeField] private Collider2D checkCollider;
        [SerializeField] private LayerMask touchingMask;

        public override bool IsEnemyInRange()
            => checkCollider.IsTouchingLayers(touchingMask);
    }
}
