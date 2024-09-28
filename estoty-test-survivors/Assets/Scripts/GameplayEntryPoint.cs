using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneContext sceneContext;
        [SerializeField] private HUDBehaviour hudBehaviour;

        private void Start()
        {
            sceneContext.Run();

            CharacterConfigScriptableObject playerConfig = sceneContext.Container.Resolve<CharacterConfigScriptableObject>();

            BaseView playerView = Instantiate(playerConfig.View);
            
            BaseCharacter presenter = playerConfig.Behaviour.Behaviour;
            sceneContext.Container.Inject(presenter);
            presenter.InitializeDataModules(playerConfig.Data);

            //link them
            playerView.SetPresenter(presenter);
            presenter.SetView(playerView);

            PlayerCharacter playerCharacter = (PlayerCharacter)presenter;
            hudBehaviour.SetPlayerInfo(playerCharacter);
        }
    }
}