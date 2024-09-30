using UnityEngine;

namespace estoty_test
{
    public class ChaseTransformMovementComponent : BaseComponent
    {
        public Transform Target;
        public Rigidbody2D Rigidbody2D;
        public MovementComponent MovementComponent;
        public EnemyFastAnimatorController AnimatorController;

        private Vector2 _moveVelocity;

        private void FixedUpdate()
        {
            if (Rigidbody2D == null || Target == null || MovementComponent == null)
                return;

            Vector2 direction = (Target.position - transform.position).normalized;
            Vector3 maxTargetVelocity = direction * MovementComponent.Data.MaxAcceleration;
            _moveVelocity = Vector2.Lerp(_moveVelocity, maxTargetVelocity, MovementComponent.Data.Acceleration * Time.fixedDeltaTime);

            Rigidbody2D.velocity = _moveVelocity;
            AnimatorController.SetMoveSpeed(_moveVelocity.sqrMagnitude / MovementComponent.Data.MaxAcceleration);
        }

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
