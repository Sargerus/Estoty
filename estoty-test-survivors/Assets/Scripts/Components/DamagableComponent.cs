using System;

namespace estoty_test
{
    public class DamagableComponent : BaseComponent
    {
        public CharacterAnimatorController CharacterAnimatorController;

        private HealthComponent _healthComponent;

        public Action OnTakeDamage;

        public void TakeDamage(float damage)
        {
            if (_healthComponent == null &&
                !TryGetComponent<HealthComponent>(out _healthComponent))

                return;

            OnTakeDamage?.Invoke();
            CharacterAnimatorController.PlayTakeDamageAnimation();   
            _healthComponent.AddHealth(-damage);
        }

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
