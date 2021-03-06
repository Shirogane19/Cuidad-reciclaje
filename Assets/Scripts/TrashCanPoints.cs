﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCanPoints : MonoBehaviour {
    //Score
    public static int scorePointsCollected;
    //HP
    public static int hp;
    // UI element <Text>Component
    private Text scorePoints;

    //Audio
    public AudioClip hit;
    public AudioClip getGoodPoint;
    AudioSource audioSource;

    private TrashSpawn trashSpawner = new TrashSpawn();
    private GameObject trashSpawnerActivation;
    private GameObject machine;

    private string tag; //Allow to know what kind of object should collide

    void Start()
    {
        scorePointsCollected = 0;
        audioSource = GetComponent<AudioSource>();
        trashSpawnerActivation = GameObject.Find("TrashSpawner");
        machine = GameObject.Find("Machine");
        //Set Life points
        hp = 3;
        //Get Texts components
        scorePoints = GameObject.Find("ScorePoints").GetComponent<Text>();
        if (gameObject.name.Equals("Organic_basket"))
        {
            tag = "Organico";
        }
        if (gameObject.name.Equals("Aluminium_basket"))
        {
            tag = "Aluminio";
        }
        if (gameObject.name.Equals("Plastic_basket"))
        {
            tag = "Envase";
        }
        if (gameObject.name.Equals("Handheld_basket"))
        {
            tag = "Residuo_Manejo";
        }
        if (gameObject.name.Equals("Glass_basket"))
        {
            tag = "Vidrio";
        }
        if (gameObject.name.Equals("Paper_basket"))
        {
            tag = "Papel_Carton";
        }
        if (gameObject.name.Equals("Ordinary_basket"))
        {
            tag = "Ordinario";
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == tag)
        {
            scorePointsCollected++;
            audioSource.PlayOneShot(getGoodPoint, 1);
        }
        else if (col.gameObject.tag == "Wall1" || col.gameObject.tag == "Wall2" || col.gameObject.tag == "Wall3" || col.gameObject.tag != tag)
        {
            audioSource.PlayOneShot(hit, 2);
            hp--;
        }


        scorePoints.text = "Puntos Reciclados: " + scorePointsCollected.ToString();
        Destroy(col.gameObject);
    }

    void Update()
    {
        if (hp == 0)
        {
            gameObject.SetActive(false);
            trashSpawnerActivation.SetActive(false);
            machine.SetActive(false);
        }
    }
}
