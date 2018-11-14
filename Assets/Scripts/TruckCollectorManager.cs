using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TruckCollectorManager : MonoBehaviour {
	//Score
	private int scoreGoodCollected;
	private int scoreWrongCollected;
	//Character Hit point(life)
	public int hp;
	// UI element <Text>Component
	private Text scoreGoodText; 
	private Text scoreWrongText;

	private string tag; //Allow to know what kind of object should collide

	void Start(){
		//Get Texts components
		scoreGoodText = GameObject.Find ("ScoreRightPoints").GetComponent<Text> ();
		scoreWrongText = GameObject.Find ("ScoreBadPoints").GetComponent<Text> ();
		//Check what kind of truck is instantiated to set its corresponding tag
		if (gameObject.name.Equals("GreenTruck(Clone)")) {
			tag = "Organico";
		}
		if (gameObject.name.Equals("YellowTruck(Clone)")) {
			tag = "Aluminio";
		}
		if (gameObject.name.Equals("BlueTruck(Clone)")) {
			tag = "Envase";
		}
		if (gameObject.name.Equals("BrownTruck(Clone)")) {
			tag = "Residuo_Manejo";
		}
		if (gameObject.name.Equals("OrangeTruck(Clone)")) {
			tag = "Vidrio";
		}
		if (gameObject.name.Equals("GrayTruck(Clone)")) {
			tag = "Papel_Carton";
		}
		if (gameObject.name.Equals("BlackTruck(Clone)")) {
			tag = "Ordinario";
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == tag) {
			scoreGoodCollected++;
		} else if (col.gameObject.tag == "Obstaculo") {
			hp--;
			Debug.Log (hp);
		} else {
			scoreWrongCollected++;
		}

		scoreGoodText.text = "Puntos Reciclados: " + scoreGoodCollected.ToString ();
		scoreWrongText.text = "Puntos incorrectos: " + scoreWrongCollected.ToString ();
	
		Destroy (col.gameObject);
	}

}
