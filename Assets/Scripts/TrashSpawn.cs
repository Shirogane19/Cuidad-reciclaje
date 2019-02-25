using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawn : MonoBehaviour {

    public float positionX = 7.49f;
    //public float randX;
    Vector2 whereToSpawn;
    public float spawnRate;
    public float nextSpawn = 0.0f;
    public int pointsToNextLevel;

    public GameObject[] obstacleTemplate;

    // Use this for initialization
    void Start () {
        setSpawnRate(4f);
        pointsToNextLevel = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextSpawn)
        {
            int option = Random.Range(0, obstacleTemplate.Length);
            nextSpawn = Time.time + spawnRate;
            whereToSpawn = new Vector2(positionX, transform.position.y);
            Instantiate(obstacleTemplate[option], whereToSpawn, Quaternion.identity);
            Debug.Log(spawnRate);
        }

        if (TrashCanPoints.scorePointsCollected == pointsToNextLevel)
        {
            if (spawnRate > 2)
            {
                spawnRate -= 1;
                this.setSpawnRate(spawnRate);
                pointsToNextLevel += 10;
            }
        }
    }

    public void setSpawnRate(float _spawnRate)
    {
        spawnRate = _spawnRate;
    }
    public float getSpawnRate()
    {
        return spawnRate;
    }
}
