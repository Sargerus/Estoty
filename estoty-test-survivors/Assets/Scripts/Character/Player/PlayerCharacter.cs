using System;
using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class PlayerCharacter : BaseEntity, IModel
    {
        private ICountDeadMonstersService _countDeadMostersService;

        [Inject]
        private void Construct([InjectOptional]ICountDeadMonstersService countDeadMostersService)
        {
            _countDeadMostersService = countDeadMostersService;
        }

        public HealthComponent HealthComponent;
        public ExperienceComponent ExperienceComponent;

        public Action<float, float> OnHpChanged { get; set; }
        public Action<int> OnExperienceChanged { get; set; }
        public Action<int> OnNewLevel { get; set; }
        public Action<int> OnKillCounterChanged { get; set; }

        public float GetMaxHP()
        {
            return HealthComponent.HealthData.MaxHP;
        }

        public float GetCurrentHP()
        {
            return HealthComponent.HealthData.CurrentHP;
        }

        public float GetCurrentLevelExperience()
        {
            return ExperienceComponent.LevelsConfig.Levels[ExperienceComponent.CurrentLevel].ExperienceRequired;
        }

        public float GetExperience()
        {
            return ExperienceComponent.CurrentExperience;
        }

        public float GetNextLevelExperience()
        {
            return ExperienceComponent.LevelsConfig
                .Levels[Mathf.Min(ExperienceComponent.LevelsConfig.Levels.Count - 1, ExperienceComponent.CurrentLevel + 1)].ExperienceRequired;
        }

        public int GetKillCounter()
        {
            int result = 0;

            if (_countDeadMostersService != null)
                result = _countDeadMostersService.DeadCount;

            return result;
        }

        private void Start()
        {
            HealthComponent.OnHpChanged += OnHpChanged;
            ExperienceComponent.OnExperienceChanged += OnExperienceChanged;
            ExperienceComponent.OnNewLevel += OnNewLevel;

            if (_countDeadMostersService != null)
            {
                _countDeadMostersService.OnCountChanged += OnKillCounterChanged;
            }
        }

        private void OnDestroy()
        {
            HealthComponent.OnHpChanged -= OnHpChanged;
            ExperienceComponent.OnExperienceChanged -= OnExperienceChanged;
            ExperienceComponent.OnNewLevel -= OnNewLevel;

            if( _countDeadMostersService != null )
            {
                _countDeadMostersService.OnCountChanged -= OnKillCounterChanged;
            }
        }
    }
}