namespace estoty_test
{
    public enum DamageType
    {
        None = 0,
        Physic = 10,
        Magic = 20
    }

    public struct DamageData
    {
        public DamageType DamageType;
        public float Damage;

        public DamageData(DamageType damageType, float damage)
        {
            DamageType = damageType;
            Damage = damage;
        }
    }
}
