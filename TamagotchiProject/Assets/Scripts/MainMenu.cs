using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject transitionPanel;

    public void Play()
    {
        transitionPanel.GetComponent<Animator>().Play("SceneEnd");
        StartCoroutine(SwitchScene());
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}