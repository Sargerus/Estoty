using UnityEngine;

namespace estoty_test
{
    [CreateAssetMenu(menuName = "[Character]/Config", fileName = "new CharacterConfig")]
    public class CharacterConfigScriptableObject : ScriptableObject
    {
        public BaseCharacterBehaviourConfigScriptableObject Behaviour;
        public BaseView View;
        public DataContainerScriptableObject Data;
    }
}
