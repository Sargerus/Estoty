namespace estoty_test
{
    public abstract class BaseBonusComponent : BaseComponent
    {
        public abstract string Type { get; }
        public override void Dispose() { Destroy(this); }
    }
}
