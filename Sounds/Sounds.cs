using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    public static Slider sliderSounds;

    void Start()
    {
        sliderSounds = GetComponent<Slider>();
        if(PlayerPrefs.HasKey("soundsVol"))
        {
            sliderSounds.value = PlayerPrefs.GetFloat("soundsVol");
        }
        
    }

    void Update()
    {
        if(sliderSounds.value != 1f)
        {
            PlayerPrefs.SetFloat("soundsVol", sliderSounds.value);
        }
    }
}