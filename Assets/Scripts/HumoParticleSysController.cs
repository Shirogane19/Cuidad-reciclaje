using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/*
 * Particle System effect, Truck smoke escape
 */
public class HumoParticleSysController : MonoBehaviour {

	public ParticleSystem Smog; 

	Rigidbody2D rb;
	private float move; // Save Axis Value for CrossPlatformInput.GetAxis
	private Vector2 position;
	//----------------------------------------------------------
	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	//----------------------------------------------------------
	void FixedUpdate () 
	{
		if (CrossPlatformInputManager.GetAxis ("Move") != 0) {
			position = new Vector2 (transform.position.x - 3,transform.position.y - 2);
			Instantiate (Smog);
			Smog.transform.position = position;
		}
	}
	//----------------------------------------------------------
}
