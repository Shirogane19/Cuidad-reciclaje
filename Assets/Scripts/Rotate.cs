using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Rotate the object
*/
public class Rotate : MonoBehaviour {

	public float speed = 50;
	//----------------------------------------------------------
	void Update () 
	{
		transform.Rotate(new Vector3(0,0,Time.deltaTime * speed));
	}
	//----------------------------------------------------------
}