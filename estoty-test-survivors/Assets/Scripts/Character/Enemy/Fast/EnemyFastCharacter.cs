using UnityEngine;

namespace estoty_test
{
    public class EnemyFastCharacter : BaseEntity
    {
        public Transform chase;

        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private DamagableComponent damagableComponent;
        [SerializeField] private ChaseTransformMovementComponent chaseTransformMovementComponent;
            
        private void Awake()
        {
            healthComponent.OnDeath += OnDeath;
            //damagableComponent.OnTakeDamage += OnTakeDamage;
        }

        private void Update()
        {
            if(chase != null)
                chaseTransformMovementComponent.Target = chase;
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            healthComponent.OnDeath -= OnDeath;
            //damagableComponent.OnTakeDamage -= OnTakeDamage;
        }
    }
}
