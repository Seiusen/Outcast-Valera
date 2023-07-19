using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    [SerializeField] public AudioSource phoneSound;
    public float distance;
    int hpDamage = 60;
    int vitalityBonus = 5;
    int alcoholBonus = 90;
    int foodBonus = 10;
    int sleepDamage = 60;
    int moneyDamage = 50;
   
    void Start()
    {
    }

    void Update()
    {
        distance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
        if (Input.GetKeyUp("space") && distance < 1.65f)
        {

            if(PlayerPrefs.HasKey("soundsVol"))
            {
                phoneSound.volume = PlayerPrefs.GetFloat("soundsVol");
                phoneSound.Play();
            }
            else
            {
                phoneSound.volume = 1f;
                phoneSound.Play();
            }

            if(Hp.hp <= 60 && Sleep.sleep <= 60 && Money.money < 50)
            {
                Hp.hp = 0;
                Sleep.sleep = 0;
                Money.money = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Валера не принес деньги и мужики решили проучить его. Отравился паленкой и остался лежать один, загрызла собака";
                return;
            }
            else if(Hp.hp <= 60 && Sleep.sleep <= 60)
            {
                Hp.hp = 0;
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Отравился водкой и уснул в рвоте";
                return;
            }
            else if(Hp.hp <= 60 && Money.money < 50)
            {
                Hp.hp = 0;
                Money.money = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Забили мужики за долги";
                return;
            }
            else if(Sleep.sleep <= 60 && Money.money < 50)
            {
                Sleep.sleep = 0;
                Money.money = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Уснул на лавочке, мужики раздели догола, забрав все, и оставили умирать от холода";
                return;
            }

            if(Hp.hp <= 60)
            {
                Hp.hp = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Печень не выдержала";
                return;
            }
            else if(Sleep.sleep <= 60)
            {
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Уснул во дворе, загрызла собака";
                return;
            }
            else if(Money.money < 50)
            {
                Money.money = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Мужики не оценили поступок и запинали Валеру";
                return;
            }

            if(Vitality.vitality < 15)
            {
                Vitality.vitality = Vitality.vitality + vitalityBonus;
            }
            else
            {
                Vitality.vitality = 20;
            }

            if(Food.food < 90)
            {
                Food.food = Food.food + foodBonus;
            }
            else
            {
                Food.food = 100;
            }

            if(Alcohol.alcohol > 10)
            {
                Alcohol.alcohol = 100;
            }
            else
            {
                Alcohol.alcohol = Alcohol.alcohol + alcoholBonus;
            }

            if(Hp.hp > 60)
            {
                Hp.hp = Hp.hp - hpDamage;
            }

            if(Sleep.sleep > 60)
            {
                Sleep.sleep = Sleep.sleep - sleepDamage;
            }

            if(Money.money >= 50)
            {
                Money.money = Money.money - moneyDamage;
            }

            
        }
    }
}
