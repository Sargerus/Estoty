namespace estoty_test
{
    public class EnemiesPool : AbstractMonoPool<IEnemyCharacterPoolableContainer>
    {
        private EnemyCharacterContainer _enemyPrefab;
        private int _initializationCount;

        public void Initialize(EnemyCharacterContainer enemyPrefab,  int initializationCount)
        {
            _enemyPrefab = enemyPrefab;
            _initializationCount = initializationCount;
        }

        public override IPooledItem<IEnemyCharacterPoolableContainer> CreateItem()
        {
            var go = Instantiate(_enemyPrefab, transform);
            go.gameObject.SetActive(false);
            go.Pool = this;
            return go.GetComponent<IEnemyCharacterPoolableContainer>();
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
