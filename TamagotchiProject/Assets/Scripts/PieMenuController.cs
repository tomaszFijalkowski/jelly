using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PieMenuController : MonoBehaviour
{
	[SerializeField] private Animation pieMenuAnimation;
	
	[SerializeField] private GameObject darkBackground;

	[SerializeField] private GameObject infoText;

	private bool pieMenuActive;
	
	public void ShowPieMenu()
	{
		if (!pieMenuActive)
		{
			pieMenuActive = true;
			pieMenuAnimation.Play("ShowPieMenu");
		}
	}

	public void HidePieMenu()
	{
		if (pieMenuActive)
		{
			pieMenuActive = false;
			pieMenuAnimation.Play("HidePieMenu");
		}
	}

	public void ActionButtonClicked(string animationName)
	{
		infoText.GetComponent<Animation>().Play("InfoTextQuickFade");
		pieMenuAnimation.Play(animationName);
	}

	public void SwitchToActionMode()
	{
		darkBackground.SetActive(true);
		
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(false);
		}
	}
}
