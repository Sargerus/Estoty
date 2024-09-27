using UnityEngine;

namespace estoty_test
{
    public class CameraFollowTarget : MonoBehaviour
    {
        private bool _isFollow;
        private Transform _target;

        public void SetFollowTarget(Transform target)
        {
            _target = target;
        }

        public void Follow(bool isFollow)
        {
            _isFollow = isFollow;
        }

        private void LateUpdate()
        {
            if (!_isFollow)
                return;

            Vector3 newpos = new(_target.position.x, _target.position.y, transform.position.z);
            transform.position = newpos;
        }
    }
}