using System.Collections;
using UnityEngine;

namespace HungerMiniGame
{
    public class FruitSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject fruitPrefab;
        [SerializeField] private GameObject sliceSomeWatermelonPrefab;
        [SerializeField] private Transform[] spawnPoints;

        private HungerMiniGame hungerMiniGame;
        private const int FruitToSpawn = 10;

        private void Start()
        {
            StartCoroutine(StartFruitSpawner());
            hungerMiniGame = GetComponentInParent<HungerMiniGame>();
        }

        private IEnumerator StartFruitSpawner()
        {
            const float minDelay = 0.3f;
            const float maxDelay = 1f;
            const float startDelay = 0.5f;

            yield return new WaitForSeconds(startDelay);

            var sliceSomeWatermelon = Instantiate(sliceSomeWatermelonPrefab, transform.position, Quaternion.identity);
            Destroy(sliceSomeWatermelon, 2f);

            yield return new WaitForSeconds(startDelay * 2);

            for (var i = 0; i < FruitToSpawn; i++)
            {
                SpawnFruit();
                yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            }

            yield return new WaitForSeconds(2f);
            hungerMiniGame.StopHungerMiniGame();
            Destroy(gameObject);
        }

        private void SpawnFruit()
        {
            var spawnIndex = Random.Range(0, spawnPoints.Length);
            var spawnPoint = spawnPoints[spawnIndex];

            var fruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
            Destroy(fruit, 5f);
        }
    }
}