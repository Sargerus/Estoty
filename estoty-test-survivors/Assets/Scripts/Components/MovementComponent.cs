namespace estoty_test
{
    public class MovementComponent : BaseComponent
    {
        public MovementData Data;

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
