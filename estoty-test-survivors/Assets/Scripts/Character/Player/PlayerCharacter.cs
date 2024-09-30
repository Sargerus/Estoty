using System;
using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class PlayerCharacter : BaseEntity, IModel
    {
        private ICountDeadMonstersService _countDeadMostersService;

        [Inject]
        private void Construct(ICountDeadMonstersService countDeadMostersService)
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
            return _countDeadMostersService.DeadCount;
        }

        private void Start()
        {
            HealthComponent.OnHpChanged += OnHpChanged;
            ExperienceComponent.OnExperienceChanged += OnExperienceChanged;
            ExperienceComponent.OnNewLevel += OnNewLevel;
            _countDeadMostersService.OnCountChanged += OnKillCounterChanged;
        }

        private void OnDestroy()
        {
            HealthComponent.OnHpChanged -= OnHpChanged;
            ExperienceComponent.OnExperienceChanged -= OnExperienceChanged;
            ExperienceComponent.OnNewLevel -= OnNewLevel;
        }
    }
}