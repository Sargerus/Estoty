using Zenject;

namespace estoty_test
{
    public class DefaultControllerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DefaultController>().AsSingle();
        }
    }
}
