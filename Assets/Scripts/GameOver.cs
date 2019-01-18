using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Show game over screen with the scores obtained
 */
public class GameOver : MonoBehaviour {

	public float timeTransitionBtwElement;
	//Sounds
	public AudioClip passPointTextSound;
	public AudioClip finalScoreSound;
	public AudioClip gameOverSound;
	AudioSource audioSource;
	public int soundVolumen;
	//Panel component
	GameObject gameOverPanel;
	//Texts components
	Text ScoreTxt;
	Text GoodScoreTxt;
	Text BadScoreTxt;
	Text TotalScoreTxt;
	//Button components
	Button RestartBtn;
	Button ExitBtn;

	public GameObject preFabGameOverPanel; 
	GameObject gameOverMenu;
	//----------------------------------------------------------
	void Awake () 
	{
		gameOverMenu = Instantiate (preFabGameOverPanel);

		audioSource = GetComponent<AudioSource> ();
		ScoreTxt = GameObject.Find ("ScoreTxt").GetComponent<Text> ();
		ScoreTxt.enabled = false;
		GoodScoreTxt = GameObject.Find ("GoodScoreTxt").GetComponent<Text> ();
		GoodScoreTxt.enabled = false;
		BadScoreTxt = GameObject.Find ("BadScoreTxt").GetComponent<Text> ();
		BadScoreTxt.enabled = false;
		TotalScoreTxt = GameObject.Find ("TotalScoreTxt").GetComponent<Text> ();
		TotalScoreTxt.enabled = false;
		RestartBtn = GameObject.Find ("Restart").GetComponent<Button> ();
		RestartBtn.gameObject.SetActive (false);
		ExitBtn = GameObject.Find("Exit").GetComponent<Button>();
		ExitBtn.gameObject.SetActive (false);

		gameOverMenu.SetActive (false);

	}
	//----------------------------------------------------------
	void Update () 
	{
		if (TruckCollectorManager.hp == 0) {
			Invoke ("sound",timeTransitionBtwElement);
			enabled = false;
		}
	}
	//----------------------------------------------------------
	void sound()
	{
		audioSource.PlayOneShot (gameOverSound,1);
		Invoke ("ShowPanel",timeTransitionBtwElement);
	}
	//----------------------------------------------------------
	void ShowPanel()
	{
		gameOverMenu.SetActive (true);
		Invoke ("showText1",timeTransitionBtwElement*2);
	}
	//----------------------------------------------------------
	void showText1()
	{
		ScoreTxt.enabled = true;
		playSound ();
		Invoke ("showText2",timeTransitionBtwElement);
	}
	//----------------------------------------------------------
	void showText2()
	{
		GoodScoreTxt.text = "Reciclables: " + TruckCollectorManager.scoreGoodCollected.ToString();
		GoodScoreTxt.enabled = true;
		playSound ();
		Invoke ("showText3",timeTransitionBtwElement);
	}
	//----------------------------------------------------------
	void showText3()
	{
		BadScoreTxt.text = "No Reciclables: " + TruckCollectorManager.scoreWrongCollected.ToString();
		BadScoreTxt.enabled = true;
		playSound ();
		Invoke ("showText4",timeTransitionBtwElement);
	}
	//----------------------------------------------------------
	void showText4()
	{
		int finalScore = TruckCollectorManager.scoreGoodCollected - TruckCollectorManager.scoreWrongCollected;
		TotalScoreTxt.text = "Total: " + finalScore.ToString ();
		TotalScoreTxt.enabled = true;
		audioSource.PlayOneShot (finalScoreSound,soundVolumen);
		Repository.setSaveTruck (finalScore);
		Invoke ("showButton",soundVolumen);
	}
	//----------------------------------------------------------
	void showButton()
	{
		RestartBtn.gameObject.SetActive (true);
		ExitBtn.gameObject.SetActive (true);	
	}
	//----------------------------------------------------------
	void playSound()
	{
		audioSource.PlayOneShot (passPointTextSound,soundVolumen);
	}
	//----------------------------------------------------------
}
