using System;

namespace estoty_test
{
    public class HealthComponent : BaseComponent
    {
        public HealthData HealthData;
        public event Action OnDeath;

        public void AddHealth(float value)
        {
            HealthData.CurrentHP += value;
            CheckHP();
        }

        private void CheckHP()
        {
            if (HealthData.CurrentHP <= 0)
            {
                OnDeath?.Invoke();
            }
        }

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
