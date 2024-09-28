using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Animator))]
    public abstract class MeleeWeaponView : MonoBehaviour
    {
        protected Animator _animator;

        protected IMeleeWeaponAttackable _attackLink;

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public virtual void Attack()
        {
            _animator.SetTrigger("attack");
        }

        public void SetAttackLink(IMeleeWeaponAttackable attackLink)
        {
            _attackLink = attackLink;
        }
    }
}
