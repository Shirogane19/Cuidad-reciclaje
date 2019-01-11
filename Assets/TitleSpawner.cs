using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSpawner : MonoBehaviour
{
	private float timeBtwSpawns; //Time between spawns objects
	public float startTimeBtwSpawns; //Time to start spawns objects
	public float minTimeSpawns;
	public float maxTimeSpawns;

	public GameObject[] obstacleTemplate;
	//----------------------------------------------------------
	private void Start()
	{
		timeBtwSpawns = startTimeBtwSpawns;
	}
	//----------------------------------------------------------
    void Update()
    {
		if (timeBtwSpawns <= 0)
		{
			int option = Random.Range(0, obstacleTemplate.Length);
			Instantiate(obstacleTemplate[option],transform.position,Quaternion.identity);

			timeBtwSpawns = Random.Range(minTimeSpawns, maxTimeSpawns);
		}
		else {
			timeBtwSpawns -= Time.deltaTime;
		}
    }
}
