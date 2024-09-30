using UnityEngine;

namespace estoty_test
{
    public class FollowTarget : MonoBehaviour
    {
        public bool IsFollow;
        public Transform Target;

        private void LateUpdate()
        {
            if (!IsFollow || !Target)
                return;

            Vector3 newpos = new(Target.position.x, Target.position.y, transform.position.z);
            transform.position = newpos;
        }
    }
}