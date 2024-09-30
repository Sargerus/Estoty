using UnityEngine;
using UnityEngine.UI;

namespace estoty_test
{
    public class ExperienceSlider : MonoBehaviour
    {
        [SerializeField] private Slider expSlider;

        private int _currentLevel;
        private ExperienceComponent _experienceComponent;

        public void Setup(ExperienceComponent experienceComponent)
        {
            _experienceComponent = experienceComponent;
            _currentLevel = _experienceComponent.CurrentLevel;
            OnExperienceChanged(_experienceComponent.CurrentExperience);

            _experienceComponent.OnExperienceChanged += OnExperienceChanged;
            _experienceComponent.OnNewLevel += OnNewLevel;
        }

        private void OnExperienceChanged(int currentExp)
        {
            expSlider.value = (float)(currentExp - _experienceComponent.LevelsConfig.Levels[_currentLevel].ExperienceRequired)
                / _experienceComponent.LevelsConfig.Levels[Mathf.Min(_experienceComponent.LevelsConfig.Levels.Count - 1, _currentLevel + 1)].ExperienceRequired;
        }

        private void OnNewLevel(int level)
        {
            _currentLevel = level;
            OnExperienceChanged(_experienceComponent.CurrentExperience);
        }

        private void OnDestroy()
        {
            if(_experienceComponent != null)
            {
                _experienceComponent.OnExperienceChanged -= OnExperienceChanged;
                _experienceComponent.OnNewLevel -= OnNewLevel;
            }
        }
    }
}
