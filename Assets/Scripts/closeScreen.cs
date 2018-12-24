using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Hide game object
 */
public class closeScreen : MonoBehaviour {

	public void closeMenu ()
	{
		GameObject menu = this.gameObject;
		menu.SetActive (false);
	}
}
