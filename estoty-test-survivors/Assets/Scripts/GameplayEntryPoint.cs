using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [SerializeField] private SceneContext sceneContext;
        [SerializeField] private HUDBehaviour hudBehaviour;
        [SerializeField] private GameObject playerPrefab;

        private void Start()
        {
            sceneContext.Run();

            var player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            var character = player.GetComponentInChildren<PlayerCharacter>();
            hudBehaviour.SetPlayerInfo(character);
        }
    }
}