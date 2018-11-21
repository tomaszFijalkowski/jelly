using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieMenu : MonoBehaviour
{
    [SerializeField] private GameObject darkBackgroundGameObject;

    [SerializeField] private GameObject hoverAreasGameObject;

    [SerializeField] private GameObject toolTipGameObject;

    private List<Image> pieMenuImages;
    private Animator pieMenuAnimator;
    private Animator toolTipAnimator;

    private bool pieMenuActive;

    private void Start()
    {
        pieMenuImages = new List<Image>();
        pieMenuAnimator = GetComponent<Animator>();
        toolTipAnimator = toolTipGameObject.GetComponent<Animator>();

        foreach (var button in GameObject.FindGameObjectsWithTag("PieMenuButton"))
        {
            pieMenuImages.Add(button.GetComponent<Image>());
        }
    }

    public void ShowPieMenu()
    {
        if (!pieMenuActive)
        {
            pieMenuActive = true;
            pieMenuAnimator.Play("PieMenuShow");
        }
    }

    public void HidePieMenu()
    {
        if (pieMenuActive)
        {
            pieMenuActive = false;
            pieMenuAnimator.Play("PieMenuHide");
        }
    }

    public void ActionButtonClicked(string animationName)
    {
        pieMenuActive = false;
        toolTipAnimator.Play("ToolTipQuickFade");

        foreach (var image in pieMenuImages)
        {
            image.raycastTarget = false;
        }

        hoverAreasGameObject.SetActive(false);
        pieMenuAnimator.Play(animationName);
    }

    public void SwitchToActionMode()
    {
        darkBackgroundGameObject.SetActive(true);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}