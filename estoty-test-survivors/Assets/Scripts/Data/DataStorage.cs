using System;
using Unity.VisualScripting;

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

    [Serializable]
    public class MeleeWeaponData : BaseData
    {
        public string Id;
        public float Damage;
        public float AttackRadius;
        public float AttackRate;
        public MeleeWeaponView View;

        [NonSerialized]
        public DateTime LastTimeAttacked = DateTime.MinValue;

        public bool CanMeleeAttack
        {
            get
            {
                DateTime nextTimeAttack = LastTimeAttacked.AddSeconds(1 / AttackRate);
                TimeSpan ts = DateTime.UtcNow - nextTimeAttack;

                return ts.TotalMilliseconds >= 0;
            }
        }

        public MeleeWeaponData(float damage, float radius, float attackRate, MeleeWeaponView view, string id)
        {
            Damage = damage;
            AttackRadius = radius;
            AttackRate = attackRate;
            View = view;
            Id = id;
        }

        public MeleeWeaponData(MeleeWeaponData other)
        {
            if (other is not MeleeWeaponData mwd)
                return;

            Id = mwd.Id;
            Damage = mwd.Damage;
            AttackRadius = mwd.AttackRadius;
            AttackRate = mwd.AttackRate;
            View = mwd.View;
        }
    }
}
