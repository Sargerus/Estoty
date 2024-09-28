using Zenject;

namespace estoty_test
{
    public class WeaponServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<WeaponService>().AsSingle();
        }
    }
}