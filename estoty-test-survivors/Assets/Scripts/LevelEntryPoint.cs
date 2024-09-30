using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class LevelEntryPoint : MonoBehaviour
    {
        [SerializeField] private FollowTarget cameraFollow;
        [SerializeField] private CharacterContainer characterPrefab;
        [SerializeField] private Transform playerSpawnPosition;
        [SerializeField] private EnemySpawner enemySpawner;

        private IView _view;
        private IController _controller;
        private ILevelLoaderService _levelLoaderService;
        private DiContainer _diContainer;

        private HealthComponent _healthComponent;

        [Inject]
        private void Construct(IView view, IController controller,
            ILevelLoaderService levelLoaderService,
            DiContainer diContainer )
        {
            _view = view;
            _controller = controller;
            _levelLoaderService = levelLoaderService;
            _diContainer = diContainer;
        }


        private void Start()
        {
            CharacterContainer player = _diContainer.InstantiatePrefabForComponent<CharacterContainer>(characterPrefab);
            player.transform.position = playerSpawnPosition.position;

            cameraFollow.Target = player.GetEntity().transform;
            cameraFollow.IsFollow = true;

            _controller.LinkModel(player.GetModel());
            _controller.LinkView(_view);

            if(player.GetEntity().TryGetComponent<HealthComponent>(out _healthComponent))
            {
                _healthComponent.OnDeath += OnDeath;
            }

            enemySpawner.StartSpawn();
        }

        private void OnDeath()
        {
            _levelLoaderService.RestartLevel();
        }

        private void OnDestroy()
        {
            enemySpawner.StopSpawn();

            if (_healthComponent != null)
                _healthComponent.OnDeath -= OnDeath;
        }
    }
}