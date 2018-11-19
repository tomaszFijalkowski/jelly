using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieMenuController : MonoBehaviour
{
	[SerializeField] private Animation pieMenuAnimation;

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
}
