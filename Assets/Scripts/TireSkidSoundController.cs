using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/*
 * Sound controller, Tire Skid Sound
 */
public class TireSkidSoundController : MonoBehaviour {

	private float move;
	public AudioClip TireSkid;
	AudioSource audioSource;

	//----------------------------------------------------------
	void Start () 
	{
		audioSource = GetComponent<AudioSource> ();
	}
	//----------------------------------------------------------
	void Update () 
	{
		//CrossPlatformInputManager return values between -1 to 1 and 0 if no moving
		move = CrossPlatformInputManager.GetAxis ("Move");
		if (move != 0) {
			audioSource.PlayOneShot (TireSkid, 1);
		} else {
			audioSource.Stop ();

		}
	}
	//----------------------------------------------------------
}
