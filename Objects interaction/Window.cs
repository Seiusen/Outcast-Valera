using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField] public AudioSource windowSound;
    public float distance;
    int hpBonus = 10;
    int alcoholDamage = 10;
    int foodDamage = 20;
    int vitalityBonus = 1;
    int sleepDamage = 10;

    void Start()
    {
    }

    void Update()
    {
        distance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
        if (Input.GetKeyUp("space") && distance < 1.6f)
        {

            if(PlayerPrefs.HasKey("soundsVol"))
            {
                windowSound.volume = PlayerPrefs.GetFloat("soundsVol");
                windowSound.Play();
            }
            else
            {
                windowSound.volume = 1f;
                windowSound.Play();
            }

            if(Food.food <= 20 && Sleep.sleep <= 10)
            {
                Food.food = 0;
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Валера оказался настолько уставшим, что забыл на каком этаже живет и прыгнул в окно за голубем";
                return;
            }

            if(Food.food > 20)
            {
                Food.food = Food.food - foodDamage;
            }
            else
            {
                Food.food = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Увидел крысу на улице, съел и заразился бешенством";
                return;
            }

            if(Sleep.sleep > 10)
            {
                Sleep.sleep = Sleep.sleep - sleepDamage;
            }
            else
            {
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Случайно выпал из окна";
                return;
            }

            if(Vitality.vitality < 20)
            {
                Vitality.vitality = Vitality.vitality + vitalityBonus;
            }
            else
            {
                Vitality.vitality = 20;
            }

            if(Hp.hp > 90)
            {
                Hp.hp = 100;
            }
            else
            {
                Hp.hp = Hp.hp + hpBonus;
            }

            if(Alcohol.alcohol < 10)
            {
                Alcohol.alcohol = 0;
            }
            else
            {
                Alcohol.alcohol = Alcohol.alcohol - alcoholDamage;
            }

            
        }
    }
}