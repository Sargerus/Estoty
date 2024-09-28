namespace estoty_test
{
    public class DamagableComponent : BaseComponent
    {
        private HealthComponent _healthComponent;

        public void TakeDamage(float damage)
        {
            if (_healthComponent == null &&
                !TryGetComponent<HealthComponent>(out _healthComponent))

                return;

            _healthComponent.AddHealth(-damage);
        }

        public override void RemoveComponent()
        {
            Destroy(this);
        }
    }
}
