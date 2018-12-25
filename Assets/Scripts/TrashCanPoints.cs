using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCanPoints : MonoBehaviour {

    //Score
    private int scorePointsCollected;
    private int scoreIncorrectPointsCollected;
    // UI element <Text>Component
    private Text scorePoints;
    private Text scoreIncorrectPoints;

    private string tag; //Allow to know what kind of object should collide

    void Start()
    {
        //Get Texts components
        scorePoints = GameObject.Find("ScorePoints").GetComponent<Text>();
        scoreIncorrectPoints = GameObject.Find("IncorrectPoints").GetComponent<Text>();
        //Check what kind of truck is instantiated to set its corresponding tag
        if (gameObject.name.Equals("Organic_basket"))
        {
            tag = "Organicos";
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
        Debug.Log(tag);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Entro");

        if (col.gameObject.tag == tag)
            scorePointsCollected++;
        else
            scoreIncorrectPointsCollected++;

        scorePoints.text = "Puntos Reciclados: " + scorePointsCollected.ToString();
        scoreIncorrectPoints.text = "Puntos incorrectos: " + scoreIncorrectPointsCollected.ToString();

        Destroy(col.gameObject);
    }
}
