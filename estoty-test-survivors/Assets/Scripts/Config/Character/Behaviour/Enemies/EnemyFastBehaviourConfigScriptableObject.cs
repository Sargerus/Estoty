using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[Behaviour]/EnemyFastBehaviour", fileName = "EnemyFastBehaviour")]
    public class EnemyFastBehaviourConfigScriptableObject : BaseCharacterBehaviourConfigScriptableObject
    {
        public override BaseCharacter Behaviour => new EnemyFastCharacter();
    }
}
