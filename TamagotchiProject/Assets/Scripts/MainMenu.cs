using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject sceneControllerGameObject;

    private SceneController sceneController;

    private void Start()
    {
        sceneController = sceneControllerGameObject.GetComponent<SceneController>();
    }

    public void Play()
    {
        sceneController.SwitchScene("MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}