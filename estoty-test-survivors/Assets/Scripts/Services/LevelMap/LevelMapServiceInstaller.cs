using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class LevelMapServiceInstaller : MonoInstaller
    {
        [SerializeField] private LevelMapService levelMapService;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelMapService>().FromInstance(levelMapService).AsSingle();
        }
    }
}
