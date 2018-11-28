using UnityEngine;

namespace HungerMiniGame
{
    public class FruitSliced : MonoBehaviour
    {
        private GameObject[] slicesGameObjects;
        private Transform[] slicesTransforms;
        private const float Force = 5f;

        private void Start()
        {
            foreach (Transform slice in transform)
            {
                var sliceRigidbody2D = slice.GetComponent<Rigidbody2D>();
                var sliceTransform = slice.GetComponent<Transform>();

                sliceRigidbody2D.AddForce(sliceTransform.up * Force, ForceMode2D.Impulse);
            }
        }
    }
}