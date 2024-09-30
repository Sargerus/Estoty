using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class LevelPoolInstaller : MonoInstaller
    {
        [SerializeField] private LevelPoolsSettingsScriptableObject levelPoolsSettingsScriptableObject;

        public override void InstallBindings()
        {
            Container.BindInstances(levelPoolsSettingsScriptableObject);
        }
    }
}
