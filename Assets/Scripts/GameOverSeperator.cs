using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverSeperator : MonoBehaviour
{
    public float timeTransitionBtwElement;
    //Sounds
    public AudioClip passPointTextSound;
    public AudioClip finalScoreSound;
    public AudioClip gameOverSound;
    AudioSource audioSource;
    public int soundVolumen;
    //Panel component
    GameObject gameOverPanel;
    //Texts components
    Text ScoreTxt;
    Text ScorePointsTxt;
    //Button components
    Button RestartBtn;
    Button ExitBtn;

    public GameObject preFabGameOverPanel;
    GameObject gameOverMenu;
    //----------------------------------------------------------
    void Awake()
    {
        gameOverMenu = Instantiate(preFabGameOverPanel);

        audioSource = GetComponent<AudioSource>();
        ScoreTxt = GameObject.Find("ScoreTxt").GetComponent<Text>();
        ScoreTxt.enabled = false;
        ScorePointsTxt = GameObject.Find("ScorePointsTxt").GetComponent<Text>();
        ScorePointsTxt.enabled = false;
        RestartBtn = GameObject.Find("Restart").GetComponent<Button>();
        RestartBtn.gameObject.SetActive(false);
        ExitBtn = GameObject.Find("Exit").GetComponent<Button>();
        ExitBtn.gameObject.SetActive(false);

        gameOverMenu.SetActive(false);

    }
    //----------------------------------------------------------
    void Update()
    {
        if (TrashCanPoints.hp == 0)
        {
            Invoke("sound", timeTransitionBtwElement);
            enabled = false;
        }
    }
    //----------------------------------------------------------
    void sound()
    {
        audioSource.PlayOneShot(gameOverSound, 1);
        Invoke("ShowPanel", timeTransitionBtwElement);
    }
    //----------------------------------------------------------
    void ShowPanel()
    {
        gameOverMenu.SetActive(true);
        Invoke("showText1", timeTransitionBtwElement * 2);
    }
    //----------------------------------------------------------
    void showText1()
    {
        ScoreTxt.enabled = true;
        playSound();
        Invoke("showText2", timeTransitionBtwElement);
    }
    //----------------------------------------------------------
    void showText2()
    {
        ScorePointsTxt.text = "Puntos reciclados: " + TrashCanPoints.scorePointsCollected.ToString();
        ScorePointsTxt.enabled = true;
        audioSource.PlayOneShot(finalScoreSound, soundVolumen);
        Repository.SaveSeparatorScore(TrashCanPoints.scorePointsCollected);
        Invoke("showButton", soundVolumen);
    }
    //----------------------------------------------------------
    void showButton()
    {
        RestartBtn.gameObject.SetActive(true);
        ExitBtn.gameObject.SetActive(true);
    }
    //----------------------------------------------------------
    void playSound()
    {
        audioSource.PlayOneShot(passPointTextSound, soundVolumen);
    }
}
