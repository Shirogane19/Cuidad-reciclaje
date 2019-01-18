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

	public static float truckMaxScore;
    public static float separatorMaxScore;
    private static float newScoreSeparator;
    private static float newScore;
	//----------------------------------------------------------
	void Awake () {
		truckMaxScore = 0;
        separatorMaxScore = 0;
		load();
	}
	//----------------------------------------------------------
	public static void SaveTruckScore(float newScore)
	{
		if (truckMaxScore < newScore) 
		{
			BinaryFormatter bf = new BinaryFormatter ();	
			FileStream file = File.Create (Application.persistentDataPath + "/ScoreData.dat");
		
			ScoreData sd = new ScoreData ();
			sd.truckScore = newScore;
			truckMaxScore = newScore;

			bf.Serialize (file,sd);
			file.Close ();
			Debug.Log ("Saved");
		}
	}
    //----------------------------------------------------------
    public static void SaveSeparatorScore(float newScore)
    {
        if (separatorMaxScore < newScore)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/ScoreData.dat");

            ScoreData sd = new ScoreData();
            sd.separatorScore = newScore;
            separatorMaxScore = newScore;

            bf.Serialize(file, sd);
            file.Close();
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
