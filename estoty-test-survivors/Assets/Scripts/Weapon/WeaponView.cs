using UnityEngine;

namespace estoty_test
{
    [RequireComponent(typeof(Animator))]
    public abstract class WeaponView : MonoBehaviour
    {
        public DamagableComponent CurrentTarget;
        public Transform ColliderParent;

        [Space(20)]
        public ColliderInRangeCheck EnemyInRangeCheck;

        protected Animator _animator;

        protected abstract bool CanAttack { get; }

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            EnemyInRangeCheck.transform.SetParent(ColliderParent);
        }

        public virtual void Attack()
        {
            _animator.SetTrigger("attack");
        }

        public virtual void SetupWeapon(int layerGo, LayerMask enemyLayerMask)
        {
            SetLayerRecursively(gameObject, layerGo);

            if (EnemyInRangeCheck != null)
                EnemyInRangeCheck.TargetLayerMask = enemyLayerMask;
        }

        private void SetLayerRecursively(GameObject go, int layer)
        {
            go.layer = layer;

            foreach (Transform child in go.transform)
            {
                SetLayerRecursively(child.gameObject, layer);
            }
        }

        protected virtual bool IsEnemyInRange()
        {
            if (EnemyInRangeCheck == null)
                return false;

            bool result = EnemyInRangeCheck.IsEnemyInRange(out var damagableComponent);
            CurrentTarget = damagableComponent;

            return result;
        }

        protected virtual void OnDestroy()
        {
            Destroy(EnemyInRangeCheck.gameObject);
        }
    }
}
