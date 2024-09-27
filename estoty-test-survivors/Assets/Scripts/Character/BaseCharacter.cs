using System;

namespace estoty_test
{
    public abstract class BaseCharacter
    {
        public MovementData MovementData;
        public HealthData HealthData;
        public ArmorData ArmorData;

        protected BaseCharacter()
        {
            MovementData = new MovementData();
            HealthData = new HealthData();
            ArmorData = new ArmorData();
        }
    }
}