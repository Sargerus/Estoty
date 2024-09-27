using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace estoty_test
{
    [Serializable]
    public abstract class BaseData { }

    [Serializable]
    public class MovementData : BaseData
    {
        public float Acceleration;
    }

    [Serializable]
    public class HealthData
    {
        public float BaseHP;
        public float CurrentHP;
        public float AdditionalHP;
    }

    [Serializable]
    public class ArmorData
    {
        public float ArmorDurability;
    }
}
