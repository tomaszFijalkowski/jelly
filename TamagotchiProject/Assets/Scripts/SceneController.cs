using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject transitionPanelGameObject;

    [SerializeField] private GameObject mainCameraGameObject;

    private Animator transitionPanelAnimator;
    private Animator mainCameraAnimator;

    private void Start()
    {
        transitionPanelAnimator = transitionPanelGameObject.GetComponent<Animator>();
        mainCameraAnimator = mainCameraGameObject.GetComponent<Animator>();
    }

    public void SwitchScene(string sceneName)
    {
        ResetGameState();
        transitionPanelAnimator.Play("SceneFadeOut");
        
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            mainCameraAnimator.SetTrigger("CameraZoomIn");
        }

        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        yield return new WaitForSeconds(0.5f);

        asyncOperation.allowSceneActivation = true;
    }

    private static void ResetGameState()
    {
        Time.timeScale = 1f;
        GameController.GamePaused = false;
        GameController.DoubleTempo = false;
    }
}