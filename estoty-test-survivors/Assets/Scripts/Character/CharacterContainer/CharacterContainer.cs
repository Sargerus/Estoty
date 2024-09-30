using UnityEngine;

namespace estoty_test
{
    public abstract class CharacterContainer : MonoBehaviour
    {
        [SerializeField] protected BaseEntity character;

        public BaseEntity GetEntity() => character;

        public IModel GetModel()
        {
            if (character is IModel model)
                return model;

            return null;
        }
    }
}
