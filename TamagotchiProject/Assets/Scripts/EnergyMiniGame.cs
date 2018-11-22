using System.Collections;
using UnityEngine;

public class EnergyMiniGame : MonoBehaviour
{
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private GameObject pieMenuGameObject;
    [SerializeField] private GameObject preventNightmaresPrefab;

    private PieMenu pieMenu;
    private GameObject[] eyes;
    private const int NumberOfGhosts = 5;
    private int ghostsLeft = NumberOfGhosts;

    private void Start()
    {
        pieMenu = pieMenuGameObject.GetComponent<PieMenu>();
        eyes = GameObject.FindGameObjectsWithTag("Eye");
    }

    private void Update()
    {
        if (ghostsLeft == 0)
        {
            StopEnergyMiniGame();
        }
    }

    public void DecreaseGhostCount()
    {
        ghostsLeft--;
    }

    public void StartEnergyMiniGame()
    {
        StartCoroutine(GhostSpawner());
        StartCoroutine(CloseEyes());
    }

    private void StopEnergyMiniGame()
    {
        pieMenu.DisableActionMode();
        ghostsLeft = NumberOfGhosts;
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

    private IEnumerator GhostSpawner()
    {
        const float radius = 6f;
        const float spawnRate = 1f;
        const float startDelay = 0.5f;

        var center = transform.position;

        yield return new WaitForSeconds(startDelay);
        Instantiate(preventNightmaresPrefab, transform.position, Quaternion.identity);

        for (var i = 0; i < NumberOfGhosts; i++)
        {
            yield return new WaitForSeconds(spawnRate);
            var angle = Random.Range(0, 360);
            var spawnPosition = GetSpawnPosition(center, radius, angle);
            Instantiate(ghostPrefab, spawnPosition, Quaternion.identity);
        }
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