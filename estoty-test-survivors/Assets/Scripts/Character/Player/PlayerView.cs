using UnityEngine;

namespace estoty_test
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : BaseView
    {
        private const string horizontalAxis = "Horizontal";
        private const string verticalAxis = "Vertical";

        private Rigidbody2D _rb2d;
        
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
            if (_rb2d == null)
                return;

            Vector2 input = new Vector3(SimpleInput.GetAxis(horizontalAxis), SimpleInput.GetAxis(verticalAxis));
            _rb2d.velocity = new();
        }

        private void Update()
        {
        }
    }
}