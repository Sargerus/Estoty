using UnityEngine;

namespace estoty_test
{
    public interface IView
    {
        void UpdateExperienceSlider(float value);
        void UpdateHealthSlider(float value);
        void UpdatePlayerLevel(int value);
        void UpdateKillCounter(int count);
    }
}
