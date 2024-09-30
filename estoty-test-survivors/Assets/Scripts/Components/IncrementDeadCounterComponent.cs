using Zenject;

namespace estoty_test
{
    public class IncrementDeadCounterComponent : BaseComponent
    {
        public HealthComponent HealthComponent;

        private ICountDeadMonstersService _countDeadMonstersService;

        [Inject]
        private void Construct([InjectOptional]ICountDeadMonstersService countDeadMonstersService)
        {
            _countDeadMonstersService = countDeadMonstersService;
        }

        private void Start()
        {
            if (HealthComponent != null)
            {
                HealthComponent.OnDeath += OnDeath;
            }
        }

        private void OnDeath()
        {
            _countDeadMonstersService?.IncrementDeadCount();
        }

        public override void Dispose()
        {
            if (HealthComponent != null)
                HealthComponent.OnDeath -= OnDeath;

            Destroy(this);
        }
    }
}
