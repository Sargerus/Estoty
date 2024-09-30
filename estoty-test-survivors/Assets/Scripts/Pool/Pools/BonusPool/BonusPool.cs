using Zenject;

namespace estoty_test
{
    public class BonusPool : AbstractMonoPool<IBonusPoolable>
    {
        private BaseBonusComponent _bonusPrefab;
        private DiContainer _diContainer;
        private int _initializationCount;

        public void Initialize(BaseBonusComponent bonusPrefab, int initializationCount, DiContainer diContainer)
        {
            _bonusPrefab = bonusPrefab;
            _initializationCount = initializationCount;
            _diContainer = diContainer;
        }

        public override IPooledItem<IBonusPoolable> CreateItem()
        {
            BaseBonusComponent go = _diContainer.InstantiatePrefabForComponent<BaseBonusComponent>(_bonusPrefab, transform);
            go.gameObject.SetActive(false);
            go.Pool = this;
            return go.GetComponent<IBonusPoolable>();
        }

        public override void DeactivateAllItems()
        {
            _trackingList.ForEach(item => item.ReturnToPool());
        }

        protected override void InitializePool()
        {
            for (int i = 0; i < _initializationCount; i++)
            {
                var item = CreateItem();
                _pool.Add(item);
                _trackingList.Add(item);
            }
        }
    }
}
