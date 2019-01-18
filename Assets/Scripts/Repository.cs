using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

/*
 * Local database managment
 */
public class Repository : MonoBehaviour {
    public static Repository instance = null;
	public static float truckMaxScore;
    public static float separatorMaxScore;
    private static float newScoreSeparator;
    private static float newScore;
	//----------------------------------------------------------
	void Awake () {

        truckMaxScore = 0;
        separatorMaxScore = 0;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        load();
        DontDestroyOnLoad(gameObject);
    }
	//----------------------------------------------------------
	public static void SaveScore()
	{
		BinaryFormatter bf = new BinaryFormatter ();	
		FileStream file = File.Create (Application.persistentDataPath + "/ScoreData.dat");
		
		ScoreData sd = new ScoreData ();
		sd.truckScore = truckMaxScore;
        sd.separatorScore = separatorMaxScore;

		bf.Serialize (file,sd);
		file.Close ();
	}
    //----------------------------------------------------------
    public static void setSaveTruck(float newScore)
    {
        if (truckMaxScore < newScore)
        {
            truckMaxScore = newScore;
            SaveScore();
        }
    }
    //---------------------------------------------------------
    public static void setSaveSeparator(float newScore)
    {
        if (separatorMaxScore < newScore)
        {
            separatorMaxScore = newScore;
            SaveScore();
        }
    }
    //----------------------------------------------------------
    public static void load()
	{
		if (File.Exists (Application.persistentDataPath + "/ScoreData.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();	
			FileStream file = File.Open (Application.persistentDataPath + "/ScoreData.dat",FileMode.Open);

			ScoreData sd = (ScoreData)bf.Deserialize (file);
			file.Close ();

			truckMaxScore = sd.truckScore;
            separatorMaxScore = sd.separatorScore;
			Debug.Log ("Loaded");
		}
	}
	//----------------------------------------------------------
	[Serializable]
	class ScoreData{
		public float truckScore;
        public float separatorScore;
	}
	//----------------------------------------------------------
}
