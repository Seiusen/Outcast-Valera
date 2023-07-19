using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public static Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        if(PlayerPrefs.HasKey("musicVol"))
        {
            slider.value = PlayerPrefs.GetFloat("musicVol");
        }
        
    }

    void Update()
    {
        if(slider.value != 1f)
        {
            PlayerPrefs.SetFloat("musicVol", slider.value);
        }
    }
}
