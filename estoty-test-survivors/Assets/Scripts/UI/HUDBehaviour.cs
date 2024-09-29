using UnityEngine;
using UnityEngine.UI;

namespace estoty_test
{
    public class HUDBehaviour : MonoBehaviour
    {
        [SerializeField] private FollowTarget cameraFollowTarget;
        [SerializeField] private Slider hpSlider;

        private HealthComponent _healthComponent;

        public void SetPlayerInfo(PlayerCharacter character)
        {
            cameraFollowTarget.Target = character.transform;
            cameraFollowTarget.IsFollow = true;

            if (character.TryGetComponent<HealthComponent>(out _healthComponent))
            {
                hpSlider.value = 1;
                _healthComponent.OnHpChanged += OnHpChanged;
            }
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
