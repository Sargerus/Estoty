using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class LevelPoolInstaller : MonoInstaller
    {
        [SerializeField] private LevelPoolsSettingsScriptableObject levelPoolsSettingsScriptableObject;
        [SerializeField] private BonusSpawner bonusSpawner;

        public override void InstallBindings()
        {
            Container.BindInstances(levelPoolsSettingsScriptableObject);

            if(bonusSpawner != null)
                Container.BindInterfacesTo<BonusSpawner>().FromInstance(bonusSpawner).AsSingle();
        }
    }
}
