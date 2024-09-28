using UnityEngine;

namespace estoty_test
{
    public class HUDBehaviour : MonoBehaviour
    {
        [SerializeField] private FollowTarget cameraFollowTarget;

        public void SetPlayerInfo(PlayerCharacter character)
        {
            cameraFollowTarget.Target = character.transform;
            cameraFollowTarget.IsFollow = true;
        }
    }
}
