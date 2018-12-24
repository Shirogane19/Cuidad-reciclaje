using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Truck game runner set max score point in the game menu
 */
public class TruckData : MonoBehaviour {

	void Start () {
		Text txt = GameObject.Find ("TruckRecordTxt").GetComponent<Text> ();
		txt.text = "Puntaje obtenido: " + Repository.truckMaxScore;
	}

}
