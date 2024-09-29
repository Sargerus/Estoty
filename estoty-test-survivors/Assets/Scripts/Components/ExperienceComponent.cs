using System;

namespace estoty_test
{
    public class ExperienceComponent : BaseComponent
    {
        public LevelConfigScriptableObject LevelsConfig;
        public int CurrentExperience;

        public Action<int> OnNewLevel;
        public Action<int> OnExperienceChanged;

        public int CurrentLevel
        {
            get
            {
                int level = 0;
                for (int i = 1; i < LevelsConfig.Levels.Count; i++)
                {
                    if (CurrentExperience < LevelsConfig.Levels[i].ExperienceRequired)
                        break;

                    level = i;
                }

                return level;
            }
        }

        public void AddExperience(int experience)
        {
            int previousLevel = CurrentLevel;
            CurrentExperience += experience;
            OnExperienceChanged?.Invoke(CurrentExperience);
            int newLevel = CurrentLevel;

            if (previousLevel != newLevel)
                OnNewLevel?.Invoke(newLevel);
        }

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
