namespace estoty_test
{
    public class CountComponent : BaseComponent
    {
        public int Count;

        public override void Dispose()
        {
            Destroy(this);
        }
    }
}
