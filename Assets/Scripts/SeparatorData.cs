using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeparatorData : MonoBehaviour
{
    void Start()
    {
        Text txt = GameObject.Find("SeparatorRecordTxt").GetComponent<Text>();
        txt.text = "Puntaje obtenido: " + Repository.separatorMaxScore;
    }
}
