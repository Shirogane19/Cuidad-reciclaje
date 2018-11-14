using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private float timeBtwSpawns; //Time between spawns objects
	public float startTimeBtwSpawns; //Time to start spawns objects
	public float minTimeSpawns;
	public float maxTimeSpawns;

	public GameObject[] obstacleTemplate;

	private void Start()
	{
		timeBtwSpawns = startTimeBtwSpawns;
	}

	private void Update()
	{
		if (timeBtwSpawns <= 0)
		{
			int option = Random.Range(0, obstacleTemplate.Length);
			Instantiate(obstacleTemplate[option]);

			timeBtwSpawns = Random.Range(minTimeSpawns, maxTimeSpawns);
		}
		else {
			timeBtwSpawns -= Time.deltaTime;
		}
	}

}
