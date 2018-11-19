using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonController : MonoBehaviour
{

	private Animation actionButtonAnimation;
	private Button actionButton;

	private void Start()
	{
		actionButtonAnimation = GetComponent<Animation>();
		actionButton = GetComponent<Button>();
	}

	public void ActionButtonClicked()
	{
		actionButtonAnimation.Play("ActionButtonClicked");
		actionButton.interactable = false;
	}
}
