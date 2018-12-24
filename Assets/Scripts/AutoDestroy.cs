using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * AutoDestroy game object in designated time
 */
public class AutoDestroy : MonoBehaviour {

	public float timeToAutoDestroid;
	//----------------------------------------------------------
	void Update () 
	{
		Destroy (gameObject,timeToAutoDestroid);
	}
	//----------------------------------------------------------
}
