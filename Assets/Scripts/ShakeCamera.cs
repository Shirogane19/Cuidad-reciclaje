using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Invoke camera animator
 */
public class ShakeCamera : MonoBehaviour {

	public Animator camAnim;
	//----------------------------------------------------------
	public void CamShake ()
	{
		camAnim.SetTrigger ("Shake");	
	}
	//----------------------------------------------------------
}
