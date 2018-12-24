using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Spawn objects in three diferents Y positions
 */
public class SpawnerWasteOnStreet : MonoBehaviour {

	private float timeBtwSpawns; //Time between spawns objects
	public float startTimeBtwSpawns; //Time to start spawns objects
	public float minTimeSpawns; // Minimum time to spawn
	public float maxTimeSpawns; // Maximum time to spawn
	public float incrementY; // Allow increase and decrease Y position

	private Vector3 posCenter; 
	private Vector3 posUp;
	private Vector3 posDown; 

	public List<GameObject> obstacleTemplate;
	//public GameObject[] obstacleTemplate;
	public List<GameObject> obstacleTemplate2;

	private int currentLevel;
	private int pointToNextLvl;
	private int pointToEachLvl;
	private int maxLvl;
	//----------------------------------------------------------
	private void Start()
	{
		timeBtwSpawns = startTimeBtwSpawns;
		posCenter = new Vector3 (transform.position.x,transform.position.y,transform.position.z);
		posUp = new Vector3 (transform.position.x,transform.position.y + incrementY,transform.position.z);
		posDown = new Vector3 (transform.position.x,transform.position.y - incrementY,transform.position.z);
		pointToEachLvl = 1;
		pointToNextLvl = pointToEachLvl;
		currentLevel = 1;
		maxLvl = 7;
	}
	//--------------------------------------------------------------
	private void Update()
	{
		if (TruckCollectorManager.scoreGoodCollected == pointToNextLvl && currentLevel < maxLvl) {
			currentLevel++;
			pointToNextLvl = pointToNextLvl + 1;
			//Debug.Log ("Level Up" + currentLevel);
		}

		if (timeBtwSpawns <= 0) {

			timeBtwSpawns = Random.Range (minTimeSpawns, maxTimeSpawns);

			int spawnOption = Random.Range (1, currentLevel + 1);

			switch (spawnOption) {
			case 1: 
				spawnLvl1 ();
				break;
			case 2:
				spawnLvl2 ();
				break;
			case 3:
				spawnLvl3 ();
				break;
			case 4:
				spawnLvl4 ();
				break;
			case 5:
				spawnLvl5 ();
				break;
			case 6:
				spawnLvl6 ();
				break;
			case 7:
				spawnLvl7 ();
				break;
			}//
				
		} else {
			timeBtwSpawns -= Time.deltaTime;
		}
	}
	//--------------------------------------------------------------
	private int getTemplateOption(List<GameObject> template)
	{
		return Random.Range(0, template.Count);
	}
	//--------------------------------------------------------------
	void spawnLvl1()
	{
		int optionPos = Random.Range(0, 3);

		Vector3 pos = posCenter;

		switch (optionPos) {
		case 1:
			pos = posUp;
			break;
		case 2:
			pos = posDown;
			break;
		}
			
		Instantiate(obstacleTemplate[getTemplateOption(obstacleTemplate)],pos,Quaternion.identity);
	}
	//--------------------------------------------------------------
	void spawnLvl2()
	{
		Instantiate(obstacleTemplate[getTemplateOption(obstacleTemplate)],posUp,Quaternion.identity);
		Instantiate(obstacleTemplate[getTemplateOption(obstacleTemplate)],posDown,Quaternion.identity);
	}
	//--------------------------------------------------------------
	void spawnLvl3()
	{
		Instantiate(obstacleTemplate[getTemplateOption(obstacleTemplate)],posCenter,Quaternion.identity);
		Instantiate(obstacleTemplate[getTemplateOption(obstacleTemplate)],posDown,Quaternion.identity);
	}
	//--------------------------------------------------------------
	void spawnLvl4()
	{
		Instantiate(obstacleTemplate[getTemplateOption(obstacleTemplate)],posUp,Quaternion.identity);
		Instantiate(obstacleTemplate[getTemplateOption(obstacleTemplate)],posCenter,Quaternion.identity);
	}
	//--------------------------------------------------------------
	void spawnLvl5()
	{
		Instantiate(obstacleTemplate2[getTemplateOption(obstacleTemplate2)],posUp,Quaternion.identity);
		Instantiate(obstacleTemplate2[getTemplateOption(obstacleTemplate2)],posDown,Quaternion.identity);
	}
	//--------------------------------------------------------------
	void spawnLvl6()
	{
		Instantiate(obstacleTemplate2[getTemplateOption(obstacleTemplate2)],posCenter,Quaternion.identity);
		Instantiate(obstacleTemplate2[getTemplateOption(obstacleTemplate2)],posDown,Quaternion.identity);
	}
	//--------------------------------------------------------------
	void spawnLvl7()
	{
		Instantiate(obstacleTemplate2[getTemplateOption(obstacleTemplate2)],posUp,Quaternion.identity);
		Instantiate(obstacleTemplate2[getTemplateOption(obstacleTemplate2)],posCenter,Quaternion.identity);
	}
	//--------------------------------------------------------------
		
		
}
