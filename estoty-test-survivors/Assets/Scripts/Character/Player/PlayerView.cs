using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : BaseView
    {
        private const string horizontalAxis = "Horizontal";
        private const string verticalAxis = "Vertical";

        [SerializeField] private bool showDebugMeleeRange;

        [SerializeField] private Transform _meleeWeaponCenter;
        [SerializeField] private Transform _rangeWeaponCenter;
        [SerializeField] private PlayerAnimatorController _playersAnimator;

        private Rigidbody2D _rb2d;
        private Vector2 _moveInput;
        private Vector2 _moveVelocity;
        private MeleeWeaponView _meleeWeaponView;
        private MeleeWeaponView _rangeWeaponView;

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

            if (_moveInput.sqrMagnitude > 0)
            {
                Vector2 maxVelocity = _moveInput * _character.MovementData.MaxAcceleration;
                _moveVelocity = Vector2.Lerp(_moveVelocity, maxVelocity, _character.MovementData.Acceleration * Time.fixedDeltaTime);
            }
            else
            {
                _moveVelocity = Vector2.Lerp(_moveVelocity, Vector2.zero, _character.MovementData.Deceleration * Time.fixedDeltaTime);
            }

            _rb2d.velocity = _moveVelocity;
            _playersAnimator.SetMoveSpeed(_moveVelocity.sqrMagnitude / _character.MovementData.MaxAcceleration);
        }

        private void Update()
        {
            if (_character == null)
                return;

            Move();

            //TODO move to another script
#if UNITY_EDITOR
            DrawDebug();
#endif
        }

        private void DrawDebug()
        {
            if (_meleeWeaponView != null && showDebugMeleeRange)
            {
                Debug.DrawCircle(transform.position, _character.MeleeWeaponData.AttackRadius, 32, Color.red);
            }
        }

        private void Move()
        {
            _moveInput = new Vector3(SimpleInput.GetAxis(horizontalAxis), SimpleInput.GetAxis(verticalAxis));
        }

        #region Melee

        public void PlayMeleeAttackAnimation()
        {
            if (_meleeWeaponView == null)
                return;

            _meleeWeaponView.Attack();
        }

        public void EquipMeleeWeapon()
        {
            if (_meleeWeaponView != null)
                Destroy(_meleeWeaponView.gameObject);

            _meleeWeaponView = Instantiate(_character.MeleeWeaponData.View, _meleeWeaponCenter.position, Quaternion.identity, _meleeWeaponCenter);
            _meleeWeaponView.SetAttackLink(_character);
        }

        #endregion

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BonusBehaviour>(out BonusBehaviour bb))
            {
                if (bb.BonusType == BonusType.Weapon)
                    _character.ReplaceWeapon(bb.Id);

                Destroy(collision.gameObject);
            }
        }
    }
}