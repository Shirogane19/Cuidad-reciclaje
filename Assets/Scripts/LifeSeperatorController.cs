using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSeperatorController : MonoBehaviour
{
    private GameObject life1, life2, life3;

    // Start is called before the first frame update
    void Start()
    {
        life1 = GameObject.Find("Life1");
        life2 = GameObject.Find("Life2");
        life3 = GameObject.Find("Life3");
    }

    // Update is called once per frame
    void Update()
    {
        switch(TrashCanPoints.hp)
        {
            case 3:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                break;
            case 2:
                life1.SetActive(true);
                life2.SetActive(false);
                life3.SetActive(false);
                break;
            case 1:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(false);
                break;
            case 0:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                break;
        }
    }
}
