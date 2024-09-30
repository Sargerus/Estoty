using Zenject;

namespace estoty_test
{
    public class CountDeadMonstersServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<CountDeadMostersService>().AsSingle();
        }
    }
}
