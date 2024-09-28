using UnityEngine;

namespace estoty_test
{
    public class ChaseTransformMovementComponent : BaseComponent
    {
        public Transform Target;
        public Rigidbody2D Rigidbody2D;
        public MovementData MovementData;
        public EnemyFastAnimatorController AnimatorController;

        private Vector2 _moveVelocity;

        private void FixedUpdate()
        {
            if (Rigidbody2D == null || Target == null)
                return;

            Vector2 direction = (Target.position - transform.position).normalized;
            Vector3 maxTargetVelocity = direction * MovementData.MaxAcceleration;
            _moveVelocity = Vector2.Lerp(_moveVelocity, maxTargetVelocity, MovementData.Acceleration * Time.fixedDeltaTime);

            Rigidbody2D.velocity = _moveVelocity;
            AnimatorController.SetMoveSpeed(_moveVelocity.sqrMagnitude / MovementData.MaxAcceleration);
        }

        public override void RemoveComponent()
        {
            Destroy(this);
        }
    }
}
