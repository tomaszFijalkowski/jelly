using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField] private GameObject toolTipGameObject;

    [SerializeField] private string label;

    private Animator toolTipAnimator;
    private Text toolTipText;

    private void Start()
    {
        toolTipAnimator = toolTipGameObject.GetComponent<Animator>();
        toolTipText = toolTipGameObject.GetComponent<Text>();
    }

    public void ElementEnter()
    {
        toolTipText.text = label;
        toolTipAnimator.Play("ToolTipShow");
    }

    public void ElementExit()
    {
        if (!toolTipAnimator.GetCurrentAnimatorStateInfo(0).IsName("ToolTipQuickFade"))
        {
            toolTipAnimator.Play("ToolTipFade");
        }
    }
}