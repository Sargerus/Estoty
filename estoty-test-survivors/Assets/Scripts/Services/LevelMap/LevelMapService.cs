using UnityEngine;

namespace estoty_test
{
    public interface ILevelMapService
    {
        Vector3 GetSpawnPosition();
    }

    public class LevelMapService : ILevelMapService
    {
        public Vector3 GetSpawnPosition()
        {
            return Vector3.zero;
        }
    }
}
