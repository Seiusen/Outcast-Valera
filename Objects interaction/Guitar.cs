using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guitar : MonoBehaviour
{
    [SerializeField] public AudioSource guitarSound;
    public float distance;
    int alcoholBonus = 10;
    int foodDamage = 20;
    int vitalityBonus = 1;
    int sleepDamage = 20;
    int moneyBonus = 10;
    int moneyHighBonus = 60;

    void Start()
    {
    }

    void Update()
    {
        distance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
        if (Input.GetKeyUp("space") && distance < 1.8f)
        {

            if(PlayerPrefs.HasKey("soundsVol"))
            {
                guitarSound.volume = PlayerPrefs.GetFloat("soundsVol");
                guitarSound.Play();
            }
            else
            {
                guitarSound.volume = 1f;
                guitarSound.Play();
            }

            if(Food.food < 21 && Sleep.sleep < 11)
            {
                Food.food = 0;
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Так давно не ел, что сил идти нет, еще и столько не спал. Валера замерз насмерть около метро";
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
                DeathLog.deathLog = "Потерял сознание от голода и упал под поезд";
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
                DeathLog.deathLog = "Уснул на путях";
                return;
            }

            if(Alcohol.alcohol < 70 && Alcohol.alcohol > 40)
            {
                Money.money = Money.money + moneyHighBonus;
            }
            else
            {
                Money.money = Money.money + moneyBonus;
            }

            if(Vitality.vitality < 20)
            {
                Vitality.vitality = Vitality.vitality + vitalityBonus;
            }
            else
            {
                Vitality.vitality = 20;
            }

            if(Alcohol.alcohol < 90)
            {
                Alcohol.alcohol = Alcohol.alcohol + alcoholBonus;
            }
            else
            {
                Alcohol.alcohol = 100;
            }

            
        }
    }
}
