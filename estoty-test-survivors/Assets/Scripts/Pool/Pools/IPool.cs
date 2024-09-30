namespace estoty_test
{
    public interface IPool<T>
    {
        IPooledItem<T> Get();
        void Add(IPooledItem<T> item);
        void DeactivateAllItems();
    }
}
