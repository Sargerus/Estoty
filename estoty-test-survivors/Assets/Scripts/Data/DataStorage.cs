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
        public float AttackRate;
        public float Damage;

        public MeleeWeaponData(float damage, float attackRate)
        {
            Damage = damage;
            AttackRate = attackRate;
        }

        public MeleeWeaponData(MeleeWeaponData other)
        {
            if (other is not MeleeWeaponData mwd)
                return;

            Damage = mwd.Damage;
            AttackRate = mwd.AttackRate;
        }
    }

    [Serializable]
    public class RangeWeaponData : BaseData
    {
        public float AttackRate;
        public float Damage;
        public float BulletVelocity;
        public float BulletMaxDistance;
        public BulletView BulletView;

        public RangeWeaponData(float damage, float attackRate, BulletView bulletView, float bulletVelocity, float bulletMaxDistance)
        {
            Damage = damage;
            AttackRate = attackRate;
            BulletView = bulletView;
            BulletVelocity = bulletVelocity;
            BulletMaxDistance = bulletMaxDistance;
        }

        public RangeWeaponData(RangeWeaponData other)
        {
            if (other is not RangeWeaponData mwd)
                return;

            Damage = mwd.Damage;
            AttackRate = mwd.AttackRate;
            BulletView = mwd.BulletView;
            BulletVelocity = mwd.BulletVelocity;
            BulletMaxDistance= mwd.BulletMaxDistance;
        }
    }

    [Serializable]
    public class CanPickUpData : BaseData { }
}
