using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/*
 * User Interface Sound Button controller, access sound through the public method or 
 * using Axis touch button Script Through axis name (Unity standart Assets)
 */
public class ButtonSounds : MonoBehaviour {

	public static ButtonSounds instance = null; 
	public int soundVolumen;
	public AudioClip button1;
	public AudioClip button2;
	public AudioClip button3;
	public AudioClip startButton;
	public AudioClip closeButton;
	AudioSource audioSource;
	private bool isBotonPressed;

	//----------------------------------------------------------
	void Start()
	{
		isBotonPressed = false;
	}
	//----------------------------------------------------------
	void Awake () 
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		audioSource = GetComponent<AudioSource> ();
	}
	//----------------------------------------------------------
	void Update()
	{
		if (CrossPlatformInputManager.GetAxis ("PlaySound1") != 0 && isBotonPressed == false) {
			isBotonPressed = true;
			playButton1 ();
		}
		if (CrossPlatformInputManager.GetAxis ("PlaySound2") != 0 && isBotonPressed == false) {
			isBotonPressed = true;
			playButton2 ();
		}
		if (CrossPlatformInputManager.GetAxis ("PlaySound3") != 0 && isBotonPressed == false) {
			isBotonPressed = true;
			playButton3 ();
		}
		if (CrossPlatformInputManager.GetAxis ("CloseSound") != 0 && isBotonPressed == false) {
			isBotonPressed = true;
			playCloseButton ();
		}
		if (CrossPlatformInputManager.GetAxis ("StartSound") != 0 && isBotonPressed == false) {
			isBotonPressed = true;
			playStartButton ();
		}
	}
	//----------------------------------------------------------
	public void playButton1()
	{
		audioSource.PlayOneShot (button1,soundVolumen);
		Invoke ("changeBottonState",2);
	}
	//----------------------------------------------------------
	public void playButton2()
	{
		audioSource.PlayOneShot (button2,soundVolumen);
		Invoke ("changeBottonState",2);
	}
	//----------------------------------------------------------
	public void playButton3()
	{
		audioSource.PlayOneShot (button3,soundVolumen);
		Invoke ("changeBottonState",1);
	}
	//----------------------------------------------------------
	public void playStartButton()
	{
		audioSource.PlayOneShot (startButton,soundVolumen);
		Invoke ("changeBottonState",2);
	}
	//----------------------------------------------------------
	public void playCloseButton()
	{
		audioSource.PlayOneShot (closeButton,soundVolumen);
		Invoke ("changeBottonState",2);
	}
	//----------------------------------------------------------
	public void changeBottonState()
	{
		isBotonPressed = false;
	}
	//----------------------------------------------------------

}
