using UnityEngine;

namespace estoty_test
{
    public class EnemyFastCharacter : BaseCharacter
    {
        [SerializeField] private HealthComponent healthComponent;
            
        private void Awake()
        {
            healthComponent.OnDeath += OnDeath;
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}
