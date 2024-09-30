using Zenject;

namespace estoty_test
{
    public class LevelMapServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelMapService>().AsSingle();
        }
    }
}
