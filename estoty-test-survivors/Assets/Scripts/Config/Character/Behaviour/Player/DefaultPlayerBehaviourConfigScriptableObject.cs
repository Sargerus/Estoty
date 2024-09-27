using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[Behaviour]/DefaultPlayerBehaviour", fileName = "DefaultPlayerBehaviour")]
    public class DefaultPlayerBehaviourConfigScriptableObject : BaseCharacterBehaviourConfigScriptableObject
    {
        public override BaseCharacter Behaviour => new PlayerCharacter();
    }
}
