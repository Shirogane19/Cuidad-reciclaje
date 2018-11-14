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

	public GameObject[] obstacleTemplate;

	private void Start()
	{
		timeBtwSpawns = startTimeBtwSpawns;
	}

	private void Update()
	{
		if (timeBtwSpawns <= 0)
		{

			int optionPos = Random.Range(0, 3);

			float extraValueY = 0;

			if (optionPos == 1) {
				extraValueY = incrementY;
			}
			if (optionPos == 2) {
				extraValueY = -incrementY;
			}

			Vector3 pos = new Vector3 (transform.position.x,transform.position.y + extraValueY,transform.position.z);

			int option = Random.Range(0, obstacleTemplate.Length);
			Instantiate(obstacleTemplate[option],pos,Quaternion.identity);

			timeBtwSpawns = Random.Range(minTimeSpawns, maxTimeSpawns);
		}
		else {
			timeBtwSpawns -= Time.deltaTime;
		}
	}
}
