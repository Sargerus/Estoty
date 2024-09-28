using System.Collections;
using UnityEngine;

namespace estoty_test
{
    public class EditorSpawner : MonoBehaviour
    {
        [SerializeField] private CharacterConfigScriptableObject cc;
        [SerializeField] private float spawnRate;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnRate);

                if (cc == null)
                    continue;

                var view = Instantiate(cc.View, Vector3.zero, Quaternion.identity);
            }
        }
    }
}
