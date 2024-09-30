using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class DefaultViewInstaller : MonoInstaller
    {
        [SerializeField] private BaseView View;

        public override void InstallBindings()
        {
            Container.Bind<IView>().FromInstance(View).AsSingle();
        }
    }
}
