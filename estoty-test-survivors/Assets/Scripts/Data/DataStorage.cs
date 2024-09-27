using System;

namespace estoty_test
{
    [Serializable]
    public abstract class BaseData
    {
    }

    [Serializable]
    public class MovementData : BaseData
    {
        public float Acceleration;
        public float MaxAcceleration;
        public float Deceleration;

        public MovementData(MovementData other)
        {
            if (other is not MovementData md)
                return;

            Acceleration = md.Acceleration;
            MaxAcceleration = md.MaxAcceleration;
            Deceleration = md.Deceleration;
        }
    }

    [Serializable]
    public class HealthData : BaseData
    {
        public float BaseHP;
        public float CurrentHP;
        public float AdditionalHP;

        public HealthData(HealthData other)
        {
            if (other is not HealthData hd)
                return;

            BaseHP = hd.BaseHP;
            CurrentHP = hd.CurrentHP;
            AdditionalHP = hd.AdditionalHP;
        }
    }

    [Serializable]
    public class ArmorData : BaseData
    {
        public float ArmorDurability;

        public ArmorData(ArmorData other)
        {
            if (other is not ArmorData ad)
                return;

            ArmorDurability = ad.ArmorDurability;
        }
    }
}
