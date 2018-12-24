using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/*
 * Allow open an game screen menu
 */
public class OpenGameMenu : MonoBehaviour {

	public GameObject preFabGameMenu;
	GameObject gameMenu;
	//----------------------------------------------------------
	void Start()
	{
	gameMenu = Instantiate (preFabGameMenu);
	gameMenu.SetActive (false);
	}
	//----------------------------------------------------------
	void OnMouseDown()
	{
		if(!gameMenu.activeSelf)
		{
			ButtonSounds Sound = GameObject.Find ("UISounds").GetComponent<ButtonSounds>();
			Sound.playButton1 ();
			gameMenu.SetActive (true);
		}
	}
	//----------------------------------------------------------
}
