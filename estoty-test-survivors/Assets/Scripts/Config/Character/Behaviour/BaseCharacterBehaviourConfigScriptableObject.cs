using UnityEngine;

namespace estoty_test
{
    public abstract class BaseCharacterBehaviourConfigScriptableObject : ScriptableObject
    {
        [TextArea]
        public string DevComment;
        public abstract BaseCharacter Behaviour { get; }
    }
}
