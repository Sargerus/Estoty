using System;

namespace estoty_test
{
    public class HealthComponent : BaseComponent
    {
        public HealthData HealthData;
        public Action OnDeath;
        public Action<float, float> OnHpChanged; //previous value, current value

        public void AddHealth(float value)
        {
            float hpNow = HealthData.CurrentHP;

            HealthData.CurrentHP += value;
            OnHpChanged?.Invoke(hpNow, HealthData.CurrentHP);
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
