using UnityEngine;

namespace estoty_test
{
    public class TouchScreenMovementComponent : BaseComponent
    {
        public Transform Target;
        public Rigidbody2D Rb2d;
        public MovementData MovementData;
        public PlayerAnimatorController AnimatorController;

        private const string horizontalAxis = "Horizontal";
        private const string verticalAxis = "Vertical";

        private Vector2 _moveInput;
        private Vector2 _moveVelocity;

        private void FixedUpdate()
        {
            if (Rb2d == null || Target == null)
                return;

            if (_moveInput.sqrMagnitude > 0)
            {
                Vector2 maxVelocity = _moveInput * MovementData.MaxAcceleration;
                _moveVelocity = Vector2.Lerp(_moveVelocity, maxVelocity, MovementData.Acceleration * Time.fixedDeltaTime);
            }
            else
            {
                _moveVelocity = Vector2.Lerp(_moveVelocity, Vector2.zero, MovementData.Deceleration * Time.fixedDeltaTime);
            }

            Rb2d.velocity = _moveVelocity;

            if (AnimatorController != null)
                AnimatorController.SetMoveSpeed(_moveVelocity.sqrMagnitude / MovementData.MaxAcceleration);
        }

        private void Update()
        {
            _moveInput = new Vector3(SimpleInput.GetAxis(horizontalAxis), SimpleInput.GetAxis(verticalAxis));
        }

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
