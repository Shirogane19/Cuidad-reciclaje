using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/*
 * Move object up or down in especific position
*/
public class TruckController : MonoBehaviour {

	/***PC Version***/
	//private Vector2 targetPosition; // new position selected by the user
	//private bool reachPosition; // Use to check the last position
	//public float incrementY; // value use to increase or decrease the Y position

	/***PC and MOBILE version***/
	public float speed; // Speed to move the object
	public float maxHeight; // Maximum height Y position
	public float minHeight; // Minimum height Y position

	/***MOBILE Version***/
	private float move; // Save Axis Value for CrossPlatformInput.GetAxis
	private Rigidbody2D rb;
	//----------------------------------------------------------
	// Get start objet position
	void Start()
	{
		/***PC version***/
		//targetPosition = transform.position;
		//reachPosition = true;
		/***MOBILEVersion****/
		rb = GetComponent<Rigidbody2D> ();
	}
	//----------------------------------------------------------
	/***
	 * Move player - MOBILE Version
	 */
	void FixedUpdate () 
	{
		move = CrossPlatformInputManager.GetAxis ("Move");

		rb.velocity = new Vector2 (0, move * 10);

		if(transform.position.y > maxHeight){
			transform.position = new Vector2 (transform.position.x, maxHeight);
		}

		if(transform.position.y < minHeight){
			transform.position = new Vector2 (transform.position.x, minHeight);
		}
	}
	//----------------------------------------------------------
	/***
	 * Move Character - PC version
	 */
//	void FixedUpdate ()
//	{
//		//Update position
//		transform.position = Vector2.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
//		//Check if reach the last position
//		if (transform.position.y == targetPosition.y) {
//			reachPosition = !reachPosition;
//		}
//		//Get new position selected by the user
//		if (reachPosition) {
//
//			if (Input.GetKeyDown (KeyCode.UpArrow) && transform.position.y < maxHeight) {
//
//				targetPosition = new Vector2 (transform.position.x, transform.position.y + incrementY);
//
//			} else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight){
//
//				targetPosition = new Vector2 (transform.position.x, transform.position.y - incrementY);
//
//			}
//
//			reachPosition = !reachPosition;
//
//		}//		
//	}
	//----------------------------------------------------------
}
