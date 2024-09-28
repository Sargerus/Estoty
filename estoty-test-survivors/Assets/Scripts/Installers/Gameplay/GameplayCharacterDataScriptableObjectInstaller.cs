using UnityEngine;
using Zenject;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[Installers]/Gameplay/GameplayInstaller", fileName = "GameplayInstaller")]
    public class GameplayCharacterDataScriptableObjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CharacterConfigScriptableObject _playerData;
        [SerializeField] private WeaponsContainerScriptableObject _weaponContainer;

        public override void InstallBindings()
        {
            Container.BindInstances(_playerData, _weaponContainer);
        }
    }
}
