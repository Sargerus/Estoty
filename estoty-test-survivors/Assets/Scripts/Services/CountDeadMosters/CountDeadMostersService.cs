using System;

namespace estoty_test
{
    public interface ICountDeadMonstersService
    {
        int DeadCount { get;}
        Action<int> OnCountChanged { get; set; }

        void IncrementDeadCount();
    }

    internal sealed class CountDeadMostersService : ICountDeadMonstersService
    {
        public int DeadCount { get; private set; }

        public Action<int> OnCountChanged { get; set; }

        public void IncrementDeadCount()
        {
            DeadCount++;
            OnCountChanged?.Invoke(DeadCount);
        }
    }
}
