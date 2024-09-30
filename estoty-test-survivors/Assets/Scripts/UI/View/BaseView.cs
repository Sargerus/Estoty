using UnityEngine;

namespace estoty_test
{
    public abstract class BaseView : MonoBehaviour, IView
    {
        public abstract void UpdateExperienceSlider(float value);
        public abstract void UpdateHealthSlider(float value);
        public abstract void UpdateKillCounter(int count);
    }
}
