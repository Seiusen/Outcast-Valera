using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChanger : MonoBehaviour
{
    [SerializeField] public AudioSource stairsSound;
    [SerializeField] public AudioSource stairsUpSound;
    public float distance;
    public int y;
    public float floor;
    
    void Start()
    {
        y = 2;
    }

    void Update()
    {
        floor = GameObject.Find("Player").transform.position.y;
        if(floor > 0)
        {
            y = 2;
        }
        else
        {
            y = 1;
        }
        distance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
        if (Input.GetKeyUp("space") && distance < 4.8f && y == 2)
        {
            GoDown();
        }
        else if(Input.GetKeyUp("space") && distance < 4.4f && y == 1)
        {
            GoUp();
        }
    }

    private void GoDown()
    {
        GameObject.Find("Player").transform.position = new Vector3 (1.305219f, -7.772964f, -0.02519043f);
        y = 1;

        if(PlayerPrefs.HasKey("soundsVol"))
        {
            stairsSound.volume = PlayerPrefs.GetFloat("soundsVol");
            stairsSound.Play();
        }
        else
        {
            stairsSound.volume = 1f;
            stairsSound.Play();
        }
    }

    private void GoUp()
    {
        GameObject.Find("Player").transform.position = new Vector3 (1.305219f, 1.744903f, -0.02519043f);
        y = 2;
        
        if(PlayerPrefs.HasKey("soundsVol"))
        {
            stairsUpSound.volume = PlayerPrefs.GetFloat("soundsVol");
            stairsUpSound.Play();
        }
        else
        {
            stairsUpSound.volume = 1f;
            stairsUpSound.Play();
        }
    }
}