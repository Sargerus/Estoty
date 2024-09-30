using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace estoty_test
{
    public abstract class AbstractMonoPool<T> : MonoBehaviour, IPool<T>
    {
        [SerializeField] private bool _dontDestroyOnLoad;

        protected List<IPooledItem<T>> _pool = new();
        protected List<IPooledItem<T>> _trackingList = new();

        private void Start()
        {
            if (_dontDestroyOnLoad)
                DontDestroyOnLoad(this);

            InitializePool();
        }

        public virtual void Add(IPooledItem<T> item)
        {
            _pool.Add(item);
        }

        public virtual IPooledItem<T> Get()
        {
            IPooledItem<T> item = default;

            if (_pool.Count == 0)
            {
                item = CreateItem();
                _pool.Add(item);
                _trackingList.Add(item);
            }

            item = _pool.First();
            _pool.Remove(item);

            return item;
        }

        public abstract IPooledItem<T> CreateItem();
        public abstract void DeactivateAllItems();
        protected abstract void InitializePool();
    }
}
