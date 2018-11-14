using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Move object up or down in especific position
*/
public class TruckController : MonoBehaviour {

	// private variables
	private Vector2 targetPosition; // new position selected by the user
	private bool reachPosition; // Use to check the last position
	// public variables
	public float incrementY; // value use to increase or decrease the Y position
	public float speed; // Speed to move the object
	public float maxHeight; // Maximum height Y position
	public float minHeight; // Minimum height Y position

	// Get start objet position
	void Start(){
		targetPosition = transform.position;
		reachPosition = true;
	}
		
	void Update () {
		//Update position
		transform.position = Vector2.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
		//Check if reach the last position
		if (transform.position.y == targetPosition.y) {
			reachPosition = !reachPosition;
		}
		//Get new position selected by the user
		if (reachPosition) {

			if (Input.GetKeyDown (KeyCode.UpArrow) && transform.position.y < maxHeight) {

				targetPosition = new Vector2 (transform.position.x, transform.position.y + incrementY);

			} else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minHeight){

				targetPosition = new Vector2 (transform.position.x, transform.position.y - incrementY);

			}

			reachPosition = !reachPosition;

		}//

			
	}



}
