using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Do not allow the game object auto destroy when load an new scene
 */
public class DoNotDestroyThis : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad (this.gameObject);
	}
}
