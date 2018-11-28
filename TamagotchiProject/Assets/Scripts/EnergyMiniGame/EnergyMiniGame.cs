using System.Collections;
using UI;
using UnityEngine;

namespace EnergyMiniGame
{
    public class EnergyMiniGame : MonoBehaviour
    {
        [SerializeField] private GameObject ghostSpawnerPrefab;
        [SerializeField] private GameObject pieMenuGameObject;

        private PieMenu pieMenu;
        private GameObject[] eyes;

        private void Start()
        {
            pieMenu = pieMenuGameObject.GetComponent<PieMenu>();
            eyes = GameObject.FindGameObjectsWithTag("Eye");
        }

        public void StartEnergyMiniGame()
        {
            Ghost.GhostCounter = 5;
            StartCoroutine(CloseEyes());
            Instantiate(ghostSpawnerPrefab, transform);
        }

        public void StopEnergyMiniGame()
        {
            pieMenu.DisableActionMode();
            OpenEyes();
        }

        private void OpenEyes()
        {
            foreach (var eye in eyes)
            {
                eye.SetActive(true);
            }
        }

        private IEnumerator CloseEyes()
        {
            yield return new WaitForSeconds(0.7f);
            foreach (var eye in eyes)
            {
                eye.SetActive(false);
            }
        }
    }
}