using System;
using UnityEngine;

namespace estoty_test
{
    public abstract class BaseComponent : MonoBehaviour, IDisposable
    {
        public abstract void Dispose();
    }

    public abstract class BaseWeaponComponent : BaseComponent
    {
        public Transform CurrentTarget;
    }
}
