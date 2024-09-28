namespace estoty_test
{
    public class EnemyFastView : BaseView
    {
        private EnemyFastCharacter _enemyFastCharacter;

        public override void SetPresenter(BaseCharacter character)
        {
            _enemyFastCharacter = (EnemyFastCharacter)character;
        }
    }
}
