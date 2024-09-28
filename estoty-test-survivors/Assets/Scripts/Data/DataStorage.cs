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
        public float MaxHP;
        public float CurrentHP;
        public float AdditionalHP;

        public HealthData(HealthData other)
        {
            if (other is not HealthData hd)
                return;

            MaxHP = hd.MaxHP;
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
        public float AttackRate;
        public float AttackSpeed;
        public float AttackRadius;
        public float Damage;

        public MeleeWeaponData(float damage, float radius, float attackRate, string id)
        {
            Damage = damage;
            AttackRadius = radius;
            AttackRate = attackRate;
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
        }
    }

    [Serializable]
    public class CanPickUpData : BaseData { }
}
