using UnityEngine;
using UnityEngine.UI;

namespace estoty_test
{
    public class HealthSlider : MonoBehaviour
    {
        [SerializeField] private Slider hpSlider;

        private HealthComponent _healthComponent;

        public void Setup(HealthComponent healthComponent)
        {
            _healthComponent = healthComponent;
            hpSlider.value = 1;
            _healthComponent.OnHpChanged += OnHpChanged;
        }

        private void OnHpChanged(float previous, float current)
        {
            hpSlider.value = current / _healthComponent.HealthData.MaxHP;
        }

        private void OnDestroy()
        {
            if (_healthComponent != null)
                _healthComponent.OnHpChanged -= OnHpChanged;
        }
    }
}
