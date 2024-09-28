using UnityEngine;

namespace estoty_test
{
    public class HUDBehaviour : MonoBehaviour
    {
        [SerializeField] private CameraFollowTarget cameraFollowTarget;

        public void SetPlayerInfo(PlayerCharacter character)
        {
            cameraFollowTarget.SetFollowTarget(character.transform);
            cameraFollowTarget.Follow(true);
        }
    }
}
