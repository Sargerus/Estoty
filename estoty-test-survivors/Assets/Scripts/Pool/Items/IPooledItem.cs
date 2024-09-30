namespace estoty_test
{
    public interface IPooledItem<T> 
    {
        T Item { get; }
        IPool<T> Pool { get; }
        void ReturnToPool();
    }
}
