using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Animator))]
    public abstract class MeleeWeaponView : MonoBehaviour
    {
        protected Animator _animator;

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public virtual void Attack()
        {
            _animator.SetTrigger("attack");
        }
    }
}
