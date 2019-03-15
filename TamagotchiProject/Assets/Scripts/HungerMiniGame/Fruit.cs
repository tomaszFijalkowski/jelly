using Controllers;
using UnityEngine;

namespace HungerMiniGame
{
    public class Fruit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem watermelonSplashGameObject;
        [SerializeField] private GameObject fruitSlicedPrefab;
        [SerializeField] private GameObject plus10HungerPrefab;

        private StatsController statsController;
        private Rigidbody2D fruitRigidbody2D;
        private Blade blade;
        private const float StartForce = 13f;

        private void Start()
        {
            blade = GameObject.FindWithTag("Blade").GetComponent<Blade>();
            statsController = GameObject.FindWithTag("Stats").GetComponent<StatsController>();
            fruitRigidbody2D = GetComponent<Rigidbody2D>();
            fruitRigidbody2D.AddForce(transform.up * StartForce, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Blade"))
            {
                MakeSplash();
                SliceFruit();
                GainHunger();
                Destroy(gameObject);
            }
        }

        private void MakeSplash()
        {
            var splash = Instantiate(watermelonSplashGameObject, transform.position, transform.rotation);
            splash.Emit(Random.Range(30, 60));
            Destroy(splash, 1f); // TODO this doesn't work for some reason (MEMORY LEAK)
        }

        private void SliceFruit()
        {
            var rotZ = Mathf.Atan2(blade.MouseDirection.y, blade.MouseDirection.x) * Mathf.Rad2Deg;
            var rotation = Quaternion.Euler(0f, 0f, rotZ - 90f);
            var fruitSlice = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            Destroy(fruitSlice, 5f);
        }

        private void GainHunger()
        {
            statsController.ChangeStats(StatsController.Stats.Hunger, 10);
            var points = Instantiate(plus10HungerPrefab, transform.position, Quaternion.identity);
            Destroy(points, 3f);
        }
    }
}