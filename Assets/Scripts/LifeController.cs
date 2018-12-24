using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Truck game ruuner User Interface life manager
 */
public class LifeController : MonoBehaviour {

	private GameObject heart1, heart2, heart3;
	//----------------------------------------------------------
	void Start()
	{
		heart1 = GameObject.Find ("Heart1");
		heart2 = GameObject.Find ("Heart2");
		heart3 = GameObject.Find ("Heart3");
	}
	//----------------------------------------------------------
	void Update () 
	{
		//Check in the script TruckCollectorManager the current character HP(life)
		switch (TruckCollectorManager.hp) {
		case 3:
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (true);
			break;
		case 2:
			heart1.SetActive (true);
			heart2.SetActive (true);
			heart3.SetActive (false);
			break;
		case 1:
			heart1.SetActive (true);
			heart2.SetActive (false);
			heart3.SetActive (false);
			break;
		case 0:
			heart1.SetActive (false);
			heart2.SetActive (false);
			heart3.SetActive (false);
			break;
		}
	}
	//----------------------------------------------------------
}
