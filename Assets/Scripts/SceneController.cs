using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

/*
 * Controls the transition between scenes and show an screen with tips and infomation
 */
public class SceneController : MonoBehaviour {

	public static SceneController instance = null; 
	public GameObject prefabLoadingScreen;
	public float delay;
	public bool isBotonPressed;

	//----------------------------------------------------------
	void Start()
	{
		isBotonPressed = false;
	}
	//----------------------------------------------------------
	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}
	//----------------------------------------------------------
	void Update () 
	{
		if (CrossPlatformInputManager.GetAxis ("StartTruck") != 0 && isBotonPressed == false) {
			isBotonPressed = true;
			StartGarbageTruckRunner ();
		}

        if (CrossPlatformInputManager.GetAxis("StartSeparator") != 0 && isBotonPressed == false)
        {
            isBotonPressed = true;
            StartGarbageSeparator();
        }

        if (CrossPlatformInputManager.GetAxis ("StartCity") != 0 && isBotonPressed == false) {
			isBotonPressed = true;
			StartCity ();
		}

        if (CrossPlatformInputManager.GetAxis("StartMainScreen") != 0 && isBotonPressed == false)
        {
            isBotonPressed = true;
            StartMainScreen();
        }

		if (CrossPlatformInputManager.GetAxis("StartCredits") != 0 && isBotonPressed == false)
		{
			isBotonPressed = true;
			StartCredits();
		}
    }
	//----------------------------------------------------------
	public void StartCity()
	{
		loadScene ("City");
	}
	//----------------------------------------------------------
	public void StartGarbageTruckRunner()
	{
		loadScene ("Garbage_truck_runner");
	}
    //----------------------------------------------------------
    public void StartGarbageSeparator()
    {
        loadScene("Garbage_Separator");
    }
    //----------------------------------------------------------
    public void StartCredits()
    {
        loadScene("Credits");
    }
    //----------------------------------------------------------
    public void StartMainScreen()
    {
        loadScene("Main_Screen");
    }
    //----------------------------------------------------------
    private void loadScene (string sceneName)
	{
		Instantiate(prefabLoadingScreen);
		StartCoroutine (LoadAsyncronously(sceneName));
	}
	//----------------------------------------------------------
	IEnumerator LoadAsyncronously(string sceneName)
	{
		yield return new WaitForSeconds(delay);
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);
		operation.allowSceneActivation = false;

		while (!operation.isDone) 
		{
			if (operation.progress >= 0.9f) 
			{
				isBotonPressed = false;
				operation.allowSceneActivation = true;
			}
			yield return null;
		}
	}
	//----------------------------------------------------------
}
