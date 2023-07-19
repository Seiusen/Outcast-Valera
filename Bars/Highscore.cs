using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text highscoreText;
    public static int hS;

    void Start()
    {
        hS = 0;
        highscoreText = GetComponent<Text>();
        if(PlayerPrefs.HasKey("SaveScore"))
        {
            hS = PlayerPrefs.GetInt("SaveScore");
        }
        highscoreText.text  = "Highscore " + hS.ToString();
    }

    void Update()
    {
        if (Days.days > hS)
        {
            highscoreText.text  = "Highscore " + Days.days.ToString();
            hS++;
            PlayerPrefs.SetInt("SaveScore", hS);
        }

        if(Input.GetKeyUp(KeyCode.R))
        {
            ResetHS();
        }
    }

    public void ResetHS()
    {
        PlayerPrefs.DeleteKey("SaveScore");
        hS = 0;
        highscoreText.text  = "Highscore " + hS.ToString();
    }
}
