using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private HUDBehaviour hudBehaviour;

        [Inject] 
        private void Construct(CharacterConfigScriptableObject playerConfig)
        {
            BaseView playerView = Instantiate(playerConfig.View);
            
            BaseCharacter presenter = playerConfig.Behaviour.Behaviour;
            presenter.InitializeDataModules(playerConfig.Data);

            //link them
            playerView.SetPresenter(presenter);
            presenter.View = playerView;

            PlayerCharacter playerCharacter = (PlayerCharacter)presenter;
            hudBehaviour.SetPlayerInfo(playerCharacter);
        }
    }
}