using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Truck game runner, score manager
 */
public class TruckCollectorManager : MonoBehaviour {
	//Score
	public static int scoreGoodCollected;
	public static int scoreWrongCollected;
	//Character Hit point(life)
	public static int hp;
	// UI element <Text>Component
	private Text scoreGoodText; 
	private Text scoreWrongText;

	public AudioClip hit;
	public AudioClip getGoodPoint;
	public AudioClip getBadPoint;
	AudioSource audioSource;

	private int pointToLevel2;

	private ShakeCamera shake;

	private string tag; //Allow to know what kind of object should collide
	//----------------------------------------------------------
	void Start()
	{
		scoreGoodCollected = 0;
		scoreWrongCollected = 0;
		pointToLevel2 = 5;
		audioSource = GetComponent<AudioSource> ();
		//Get camera component
		shake = GameObject.FindGameObjectWithTag ("ScreenShake").GetComponent<ShakeCamera> ();
		//Set Life points
		hp = 3;
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
	//----------------------------------------------------------
	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == tag) {
			scoreGoodCollected++;
			audioSource.PlayOneShot (getGoodPoint,1);
		} else if (col.gameObject.tag == "Obstaculo") {
			audioSource.PlayOneShot (hit,2);
			shake.CamShake ();
			hp--;
		} else {
			scoreWrongCollected++;
			audioSource.PlayOneShot (getBadPoint,1);
		}

		scoreGoodText.text = "Reciclables: " + scoreGoodCollected.ToString ();
		scoreWrongText.text = "No Reciclables: " + scoreWrongCollected.ToString ();
		Destroy (col.gameObject);
	}
	//----------------------------------------------------------
	void Update()
	{
		if(hp == 0){
			gameObject.SetActive (false);
		}
	}	
	//----------------------------------------------------------
}
