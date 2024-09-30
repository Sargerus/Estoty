using UnityEngine;

namespace estoty_test
{
    public interface IBonusPoolable : IPooledItem<IBonusPoolable>
    {
        GameObject gameObject { get; }
    }

    public abstract class BaseBonusComponent : BaseComponent, IBonusPoolable
    {
        public IBonusPoolable Item => this;

        public IPool<IBonusPoolable> Pool { get; set; }

        public void ReturnToPool()
        {
            gameObject.SetActive(false);
            Pool.Add(Item);
        }
        public override void Dispose() { Destroy(this); }
    }
}
