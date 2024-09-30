using UnityEngine;
using Zenject;

namespace estoty_test
{
    public interface ILevelLoaderService
    {
        void RestartLevel();
    }

    public class LevelLoaderService : ILevelLoaderService, IInitializable
    {
        private LevelContainerScriptableObject _levelContainer;
        private DiContainer _diContainer;

        private GameObject _currentLevel;
        private int _levelProgress;

        public LevelLoaderService(LevelContainerScriptableObject levelContainer, DiContainer diContainer)
        {
            _levelContainer = levelContainer;
            _diContainer = diContainer;
        }

        public void Initialize()
        {
            LoadLevel();
        }

        public void RestartLevel()
        {
            if (_currentLevel != null)
            {
                GameObject.Destroy(_currentLevel);
            }

            LoadLevel();
        }

        private void LoadLevel()
        {
            _currentLevel = _diContainer.InstantiatePrefab(_levelContainer.Levels[_levelProgress % _levelContainer.Levels.Count]);
        }
    }
}
