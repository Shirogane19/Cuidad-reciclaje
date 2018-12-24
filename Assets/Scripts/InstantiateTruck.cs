using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Instatiate one gameObject in List of gameObjects
 */
public class InstantiateTruck : MonoBehaviour {

	public GameObject[] trucks;
	//----------------------------------------------------------
	void Awake () 
	{
		int truckNumber = Random.Range(0, trucks.Length);
		Instantiate (trucks[truckNumber],transform.position,Quaternion.identity);
	}
	//----------------------------------------------------------
}
