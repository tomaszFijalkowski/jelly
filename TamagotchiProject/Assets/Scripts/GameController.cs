using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool GamePaused;
    public static bool DoubleTempo;

    [SerializeField] private GameObject pauseMenuGameObject;

    [SerializeField] private GameObject pieMenuGameObject;

    [SerializeField] private GameObject toolTipGameObject;

    private Transform[] pauseMenuElements;
    private PieMenu pieMenu;
    private Animator toolTipAnimator;

    private void Start()
    {
        pieMenu = pieMenuGameObject.GetComponent<PieMenu>();
        toolTipAnimator = toolTipGameObject.GetComponent<Animator>();
        pauseMenuElements = pauseMenuGameObject.GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("escape"))
        {
            TogglePause();
        }
    }

    public void ChangeTempo()
    {
        Time.timeScale = !DoubleTempo ? 2f : 1f;
        DoubleTempo = !DoubleTempo;
    }

    public void TogglePause()
    {
        ResetPauseScreen();

        if (!GamePaused)
        {
            Pause();
        }
        else
        {
            UnPause();
        }

        GamePaused = !GamePaused;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuGameObject.SetActive(true);
        pieMenu.HidePieMenu();

        if (!toolTipAnimator.GetCurrentAnimatorStateInfo(0).IsName("ToolTipFade"))
        {
            toolTipAnimator.Play("ToolTipQuickFade");
        }
    }

    private void UnPause()
    {
        Time.timeScale = DoubleTempo ? 2f : 1f;
        pauseMenuGameObject.SetActive(false);
    }

    private void ResetPauseScreen()
    {
        foreach (var element in pauseMenuElements)
        {
            element.localScale = new Vector3(0.8f, 0.8f, 1f);
        }
    }
}