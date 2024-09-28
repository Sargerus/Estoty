using UnityEngine;

namespace estoty_test
{
    public class CharacterAnimatorController : MonoBehaviour
    {
        protected const string MoveSpeed = nameof(MoveSpeed);
        private const string Hit = nameof(Hit);

        [SerializeField] protected Animator _playerAnimator;

        public void PlayTakeDamageAnimation()
        {
            _playerAnimator.SetTrigger(Hit);
        }

        public void SetMoveSpeed(float speed)
        {
            if (speed < 0.01)
                speed = 0;

            _playerAnimator.SetFloat(MoveSpeed, Mathf.Lerp(0, 1, speed));
        }
    }
}
