
using UnityEngine;

namespace estoty_test
{
    public interface ILevelMapService
    {
        bool TryGetSpawnPosition(out Vector3 spawnPosition);
    }

    public class LevelMapService : MonoBehaviour, ILevelMapService
    {
        [SerializeField] private Camera playersCamera;
        [SerializeField] private BoxCollider2D arena;


        public bool TryGetSpawnPosition(out Vector3 spawnPosition)
        {
            spawnPosition = Vector3.zero;

            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            direction.y *= playersCamera.orthographicSize * Random.Range(1.5f, 2.5f);
            direction.x *= playersCamera.aspect * playersCamera.orthographicSize * 2f * Random.Range(1.5f, 2.5f);

            Vector3 arenaCenter = arena.transform.TransformPoint(arena.offset);
            Vector2 arenaExtents = arena.size * 0.5f;

            spawnPosition = playersCamera.ViewportToWorldPoint(new Vector2(0.5f, 0.5f)) + direction;
            spawnPosition.z = 0;

            if (IsBetween(spawnPosition.x, arenaCenter.x - arenaExtents.x, arenaCenter.x + arenaExtents.x)
                && IsBetween(spawnPosition.y, arenaCenter.y - arenaExtents.y, arenaCenter.y + arenaExtents.y))
            {
                return true;
            }

            return false;
        }

        private bool IsBetween(float value, float min, float max)
        {
            return value >= min && value <= max;
        }
    }
}
