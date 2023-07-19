using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{

    [SerializeField] public AudioSource mainMenuSound;

    void Start()
    {
        if(PlayerPrefs.HasKey("musicVol"))
        {
            mainMenuSound.volume = PlayerPrefs.GetFloat("musicVol");
            mainMenuSound.Play();
        }
        else
        {
            mainMenuSound.volume = 1f;
            mainMenuSound.Play();
        }
    }
}
