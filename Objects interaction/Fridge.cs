using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fridge : MonoBehaviour
{
    [SerializeField] public AudioSource fridgeSound;
    public float distance;
    int hpDamage = 5;
    int alcoholDamage = 5;
    int foodBonus = 20;
    int vitalityDamage = 2;
    int sleepDamage = 5;
    int moneyDamage = 15;

    void Start()
    {
        
    }

    void Update()
    {
        distance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
        if (Input.GetKeyUp("space") && distance < 1.6f && Money.money > 15)
        {

            if(PlayerPrefs.HasKey("soundsVol"))
            {
                fridgeSound.volume = PlayerPrefs.GetFloat("soundsVol");
                fridgeSound.Play();
            }
            else
            {
                fridgeSound.volume = 1f;
                fridgeSound.Play();
            }

            if(Hp.hp <=5 && Vitality.vitality <=2 && Sleep.sleep <= 5)
            {
                Hp.hp = 0;
                Vitality.vitality = 0;
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Не сплю три дня из-за разрывающей боли от язвы, все из-за этого доширака. Лучше я сдохну! Валера повесился";
                return;
            }
            else if(Hp.hp <=5 && Vitality.vitality <=2)
            {
                Hp.hp = 0;
                Vitality.vitality = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Боли в животе сводят с ума, теперь еще и есть не могу. Умер от голода";
                return;
            }
            else if(Hp.hp <=5 && Sleep.sleep <= 5)
            {
                Hp.hp = 0;
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog ="Захлебнулся в пене изо рта";
                return;
            }
            else if(Vitality.vitality <=2 && Sleep.sleep <= 5)
            {
                Vitality.vitality = 0;
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Я устал от такой жизни, 20 лет в никуда. Прыгнул из окна";
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
                DeathLog.deathLog = "Умер от язвы";
                return;
            }

            if(Vitality.vitality > 2)
            {
                Vitality.vitality = Vitality.vitality - vitalityDamage;
            }
            else
            {
                Vitality.vitality = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Снова этот доширак! Повесился с горя";
                return;
            }

            if(Sleep.sleep <= 5)
            {
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Уснул лицом в дошираке, задохнулся";
                return;
            }

            Money.money = Money.money - moneyDamage;

            if(Sleep.sleep > 5)
            {
                Sleep.sleep = Sleep.sleep - sleepDamage;
            }

            if(Alcohol.alcohol > 5)
            {
                Alcohol.alcohol = Alcohol.alcohol - alcoholDamage;
            }
            else
            {
                Alcohol.alcohol = 0;
            }

            if(Food.food > 80)
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