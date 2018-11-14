using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTruck : MonoBehaviour {

	public GameObject[] trucks;
	// Use this for initialization
	void Awake () {
		int truckNumber = Random.Range(0, trucks.Length);
		Instantiate (trucks[truckNumber],transform.position,Quaternion.identity);
	}

}
