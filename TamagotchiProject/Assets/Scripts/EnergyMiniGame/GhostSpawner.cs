using System.Collections;
using UnityEngine;

namespace EnergyMiniGame
{
    public class GhostSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject ghostPrefab;
        [SerializeField] private GameObject preventNightmaresPrefab;

        private const int GhostsToSpawn = 5;

        private void Start()
        {
            StartCoroutine(StartGhostSpawner());
        }

        private IEnumerator StartGhostSpawner()
        {
            const float radius = 6f;
            const float spawnRate = 1f;
            const float startDelay = 0.5f;

            var center = transform.position;

            yield return new WaitForSeconds(startDelay);

            var preventNightmares = Instantiate(preventNightmaresPrefab, transform.position, Quaternion.identity);
            Destroy(preventNightmares, 2f);

            yield return new WaitForSeconds(startDelay * 2);

            for (var i = 0; i < GhostsToSpawn; i++)
            {
                SpawnGhost(center, radius);
                yield return new WaitForSeconds(spawnRate);
            }

            Destroy(gameObject);
        }

        private void SpawnGhost(Vector3 center, float radius)
        {
            var angle = Random.Range(0, 360);
            var spawnPosition = GetSpawnPosition(center, radius, angle);
            Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
        }

        private Vector3 GetSpawnPosition(Vector3 center, float radius, float angle)
        {
            Vector3 position;
            position.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
            position.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            position.z = center.z;
            return position;
        }
    }
}