using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] public AudioSource menuSound;
    

    void Start()
    {
        menuSound.volume = Music.slider.value;
        menuSound.Play();
    }

    void Update() {
        menuSound.volume = Music.slider.value;
    }

}