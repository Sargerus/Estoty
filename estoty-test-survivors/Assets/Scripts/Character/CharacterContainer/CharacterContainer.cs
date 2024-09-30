using UnityEngine;

namespace estoty_test
{
    public class CharacterContainer : MonoBehaviour
    {
        [SerializeField] private BaseEntity character;

        public BaseEntity GetEntity() => character;

        public IModel GetModel()
        {
            if(character is IModel model)
                return model;

            return null;
        }
    }
}
