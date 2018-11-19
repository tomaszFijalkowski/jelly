using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour {
	
	public void MenuButtonEnter()
	{
		GetComponent<Animation>().Play("MenuButtonEnter");
	}
	
	public void MenuButtonExit()
	{
		GetComponent<Animation>().Play("MenuButtonExit");
	}
}
