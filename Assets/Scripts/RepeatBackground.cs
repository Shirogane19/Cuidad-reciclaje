using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Move object to the left and set in new position when it reaches the end position x  
*/
public class RepeatBackground : MonoBehaviour {

	//Public Variables
	public float speed;
	public float endX; // End position X
	public float startX; // Start position Y 

	void Update () {

		transform.Translate(Vector2.left * speed * Time.deltaTime);

		if (transform.position.x <= endX) {
			transform.position = new Vector2 (startX, transform.position.y);
		}
		
	}
}
