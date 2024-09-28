using UnityEngine;

namespace estoty_test
{
    public abstract class BaseCharacter : MonoBehaviour
    {
        public virtual BaseView View { get; protected set; }
    }
}