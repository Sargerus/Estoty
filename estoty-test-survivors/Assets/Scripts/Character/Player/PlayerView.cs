using System;
using UnityEngine;

namespace estoty_test
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : BaseView
    {
        private const string horizontalAxis = "Horizontal";
        private const string verticalAxis = "Vertical";

        private Rigidbody2D _rb2d;
        private Vector2 _moveInput;
        private Vector2 _moveVelocity;

        private PlayerCharacter _character;

        public override void SetPresenter(BaseCharacter character)
        {
            _character = (PlayerCharacter)character;
        }

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_rb2d == null || _character == null)
                return;

            if(_moveInput.sqrMagnitude > 0)
            {
                Vector2 maxVelocity = _moveInput * _character.MovementData.MaxAcceleration;
                _moveVelocity = Vector2.Lerp(_moveVelocity, maxVelocity, _character.MovementData.Acceleration * Time.fixedDeltaTime);
            }
            else
            {
                _moveVelocity = Vector2.Lerp(_moveVelocity, Vector2.zero, _character.MovementData.Deceleration * Time.fixedDeltaTime);
            }
            
            _rb2d.velocity = _moveVelocity;
        }

        private void Update()
        {
            if (_character == null)
                return;

            Move();

        }

        private void Move()
        {
            _moveInput = new Vector3(SimpleInput.GetAxis(horizontalAxis), SimpleInput.GetAxis(verticalAxis));
        }
    }
}