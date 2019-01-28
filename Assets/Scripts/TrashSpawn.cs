using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawn : MonoBehaviour {

    public float positionX = 7.49f;
    //public float randX;
    Vector2 whereToSpawn;
    public float spawnRate;
    public float nextSpawn = 0.0f;

    public GameObject[] obstacleTemplate;

    // Use this for initialization
    void Start () {
        setSpawnRate(5f);
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
