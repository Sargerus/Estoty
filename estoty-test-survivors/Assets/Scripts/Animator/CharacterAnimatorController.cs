using UnityEngine;

namespace estoty_test
{
    public class CharacterAnimatorController : MonoBehaviour
    {
        private const string MoveSpeed = nameof(MoveSpeed);

        [SerializeField] private Animator _playerAnimator;

        public void SetMoveSpeed(float speed)
        {
            if (speed < 0.01)
                speed = 0;

            _playerAnimator.SetFloat(MoveSpeed, Mathf.Lerp(0, 1, speed));
        }
    }
}
