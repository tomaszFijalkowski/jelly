using UnityEngine;

namespace HungerMiniGame
{
    public class Blade : MonoBehaviour
    {
        public Vector2 MouseDirection;

        [SerializeField] private GameObject bladeTrailPrefab;

        private Rigidbody2D bladeRigidbody2D;
        private CircleCollider2D bladeCircleCollider2D;
        private Camera mainCamera;

        private GameObject currentBladeTrail;

        private bool isCutting;
        private Vector2 previousPosition;

        private const float MinCuttingVelocity = 10f;

        private void Start()
        {
            bladeRigidbody2D = GetComponent<Rigidbody2D>();
            bladeCircleCollider2D = GetComponent<CircleCollider2D>();
            mainCamera = Camera.main;

            bladeCircleCollider2D.enabled = false;

            if (mainCamera != null)
            {
                previousPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCutting();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopCutting();
            }

            if (isCutting)
            {
                UpdateCut();
            }
        }

        private void UpdateCut()
        {
            Vector2 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            bladeRigidbody2D.position = newPosition;

            var velocity = (newPosition - previousPosition).magnitude / Time.deltaTime;

            MouseDirection = new Vector2(
                newPosition.x - previousPosition.x,
                newPosition.y - previousPosition.y
            );

            bladeCircleCollider2D.enabled = velocity > MinCuttingVelocity;

            previousPosition = newPosition;
        }

        private void StartCutting()
        {
            isCutting = true;
            currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
            previousPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            bladeCircleCollider2D.enabled = false;
        }

        private void StopCutting()
        {
            isCutting = false;
            currentBladeTrail.transform.SetParent(null);
            Destroy(currentBladeTrail, 1f);
            bladeCircleCollider2D.enabled = false;
        }
    }
}