using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace estoty_test
{
    public interface IModel
    {
        float GetMaxHP();
        float GetCurrentHP();

        float GetExperience();
        float GetCurrentLevelExperience();
        float GetNextLevelExperience();

        int GetKillCounter();

        Action<float, float> OnHpChanged { get; set; }
        Action<int> OnExperienceChanged { get; set; }
        Action<int> OnNewLevel { get; set; }
        Action<int> OnKillCounterChanged { get; set; }
    }

    public class DefaultView : BaseView
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Slider experienceSlider;
        [SerializeField] private TMP_Text killCounter;
        [SerializeField] private TMP_Text playersLevel;

        public override void UpdateExperienceSlider(float value)
        {
            experienceSlider.value = value;
        }

        public override void UpdateHealthSlider(float value)
        {
            healthSlider.value = value;
        }

        public override void UpdateKillCounter(int count)
        {
            killCounter.SetText(count.ToString());
        }

        public override void UpdatePlayerLevel(int value)
        {
            playersLevel.SetText($"Lvl {value}");
        }
    }
}
