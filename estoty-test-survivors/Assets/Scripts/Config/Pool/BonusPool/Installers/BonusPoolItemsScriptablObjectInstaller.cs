using UnityEngine;
using Zenject;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[Pools]/BonusPool/BonusPoolInstaller", fileName = "new BonusPoolItemsInstaller")]
    public class BonusPoolItemsScriptablObjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private BonusPoolItemsScriptableObject BonusPoolItems;

        public override void InstallBindings()
        {
            Container.BindInstances(BonusPoolItems);
        }
    }
}
