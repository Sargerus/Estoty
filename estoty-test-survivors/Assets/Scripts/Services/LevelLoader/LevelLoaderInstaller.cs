using Zenject;

namespace estoty_test
{
    public class LevelLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelLoaderService>().AsSingle().NonLazy();
        }
    }
}
