using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerView : BaseView
    {
        [SerializeField] private PlayerCharacter character;
        [SerializeField] private bool showDebugMeleeRange;
        [SerializeField] private PlayerAnimatorController _playersAnimator;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BonusBehaviour bb))
            {
                character.ApplyBonus(bb.BonusData);            
                Destroy(collision.gameObject);
            }
        }
    }
}