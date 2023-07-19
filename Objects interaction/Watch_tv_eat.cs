using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Watch_tv_eat : MonoBehaviour
{
    [SerializeField] public AudioSource tvSound;
    public float distance;
    int hpDamage = 5;
    int alcoholBonus = 40;
    int foodBonus = 40;
    int vitalityBonus = 2;
    int sleepDamage = 5;
    int moneyDamage = 30;

    void Start()
    {
    }

    void Update()
    {
        distance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
        if (Input.GetKeyUp("space") && distance < 4.7f && Money.money > 30)
        {

            if(PlayerPrefs.HasKey("soundsVol"))
            {
                tvSound.volume = PlayerPrefs.GetFloat("soundsVol");
                tvSound.Play();
            }
            else
            {
                tvSound.volume = 1f;
                tvSound.Play();
            }

            if(Hp.hp <= 5 && Sleep.sleep <=5)
            {
                Hp.hp = 0;
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "У Валеры отказали ноги, не в силах тащить себя руками, умер от жажды и голода";
                return;
            }

            if(Hp.hp > 5)
            {
                Hp.hp = Hp.hp - hpDamage;
            }
            else
            {
                Hp.hp = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Продали бодягу с просрочкой";
                return;
            }

            if(Sleep.sleep > 5)
            {
                Sleep.sleep = Sleep.sleep - sleepDamage;
            }
            else
            {
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Уснул с вилкой в руке и проткнул себе глаз";
                return;
            }

            Money.money = Money.money - moneyDamage;

            if(Vitality.vitality > 18)
            {
                Vitality.vitality = 20;
            }
            else
            {
                Vitality.vitality = Vitality.vitality + vitalityBonus;
            }

            if(Alcohol.alcohol > 60)
            {
                Alcohol.alcohol = 100;
            }
            else
            {
                Alcohol.alcohol = Alcohol.alcohol + alcoholBonus;
            }

            if(Food.food > 60)
            {
                Food.food = 100;
            }
            else
            {
                Food.food = Food.food + foodBonus;
            }

            
        }
    }
}