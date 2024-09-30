using System;
using UnityEngine;

namespace estoty_test
{
    public class DefaultController : IController
    {
        private IModel _model;
        private IView _view;

        public void LinkModel(IModel model)
        {
            Unsubscribe();
            _model = model;

            SetupView();
        }

        public void LinkView(IView view)
        {
            _view = view;
            SetupView();
        }

        private void SetupView()
        {
            if (_model == null || _view == null)
                return;

            _view.UpdateHealthSlider(_model.GetCurrentHP() / Mathf.Max(1, _model.GetMaxHP()));

            float currentLevelExp = _model.GetCurrentLevelExperience();
            float nextLevelExp = _model.GetNextLevelExperience();
            _view.UpdateExperienceSlider((_model.GetExperience() - currentLevelExp) / Mathf.Max(1, (currentLevelExp - nextLevelExp)));

            _view.UpdateKillCounter(_model.GetKillCounter());

            Subscribe();
        }

        private void Subscribe()
        {
            if (_model == null)
                return;

            _model.OnHpChanged += OnHpChanged;
            _model.OnExperienceChanged += OnExperienceChanged;
            _model.OnKillCounterChanged += OnKillCounterChanged;
            _model.OnNewLevel += OnNewLevel;
        }

        private void Unsubscribe()
        {
            if (_model == null)
                return;

            _model.OnHpChanged -= OnHpChanged;
            _model.OnExperienceChanged -= OnExperienceChanged;
            _model.OnKillCounterChanged -= OnKillCounterChanged;
            _model.OnNewLevel -= OnNewLevel;
        }

        private void OnHpChanged(float previous, float current)
        {
            _view.UpdateHealthSlider(current / _model.GetMaxHP());
        }

        private void OnExperienceChanged(int currentExp)
        {
            float currentLevelExp = _model.GetCurrentLevelExperience();
            float nextLevelExp = _model.GetNextLevelExperience();
            _view.UpdateExperienceSlider((float)(_model.GetExperience() - currentLevelExp) / Mathf.Max(1, (nextLevelExp - currentLevelExp)));
        }

        private void OnKillCounterChanged(int count)
        {
            _view.UpdateKillCounter(count);
        }

        private void OnNewLevel(int level)
        {
            _view.UpdatePlayerLevel(level);
        }

        public void Dispose()
        {
            Unsubscribe();
        }
    }
}
