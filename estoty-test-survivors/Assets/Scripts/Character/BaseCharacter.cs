namespace estoty_test
{
    public abstract class BaseCharacter
    {
        public BaseView View;

        public MovementData MovementData;
        public HealthData HealthData;
        public ArmorData ArmorData;

        public virtual void InitializeDataModules(DataContainerScriptableObject container)
        {
            foreach (var dataModule in container.DataModules)
            {
                if (dataModule is MovementDataScriptableObject md)
                    MovementData = new(md.Data);
            }
        }
    }
}