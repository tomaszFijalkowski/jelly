using UI;
using UnityEngine;

namespace HungerMiniGame
{
    public class HungerMiniGame : MonoBehaviour
    {
        [SerializeField] private GameObject fruitSpawnerPrefab;
        [SerializeField] private GameObject bladePrefab;
        [SerializeField] private GameObject pieMenuGameObject;

        private PieMenu pieMenu;
        private GameObject bladeGameObject;

        private void Start()
        {
            pieMenu = pieMenuGameObject.GetComponent<PieMenu>();
        }

        public void StartHungerMiniGame()
        {
            bladeGameObject = Instantiate(bladePrefab, transform);
            Instantiate(fruitSpawnerPrefab, transform);
        }

        public void StopHungerMiniGame()
        {
            Destroy(bladeGameObject);
            pieMenu.DisableActionMode();
        }
    }
}