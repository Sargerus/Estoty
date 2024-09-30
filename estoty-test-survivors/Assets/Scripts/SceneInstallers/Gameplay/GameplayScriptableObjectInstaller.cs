using UnityEngine;
using Zenject;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[SceneInstallers]/Gameplay/ScriptableObjectInstaller", fileName = "new ScriptableObjectInstaller")]
    public class GameplayScriptableObjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private LevelContainerScriptableObject levelContainerScriptableObject;

        public override void InstallBindings()
        {
            Container.BindInstances(levelContainerScriptableObject);
        }
    }
}
