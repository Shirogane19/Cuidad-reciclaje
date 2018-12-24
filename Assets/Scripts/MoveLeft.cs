using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Move game object to the left
 */
public class MoveLeft : MonoBehaviour {

	//Public Variables
	public float speed;
	//----------------------------------------------------------
	void Update () 
	{
		transform.Translate (Vector2.left * speed * Time.deltaTime);
	}
	//----------------------------------------------------------
}
