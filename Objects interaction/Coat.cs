using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coat : MonoBehaviour
{
    [SerializeField] public AudioSource coatSound;
    public float distance;
    int hpDamage = 10;
    int vitalityBonus = 5;
    int alcoholBonus = 60;
    int foodBonus = 20;
    int sleepDamage = 40;
    int moneyDamage = 100;

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
                coatSound.volume = PlayerPrefs.GetFloat("soundsVol");
                coatSound.Play();
            }
            else
            {
                coatSound.volume = 1f;
                coatSound.Play();
            }

            if(Hp.hp <= 10 && Sleep.sleep <= 40 && Money.money < 100)
            {
                Hp.hp = 0;
                Sleep.sleep = 0;
                Money.money = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Приняли за бомжа и устроили поножовщину";
                return;
            }
            else if(Hp.hp <= 10 && Sleep.sleep <= 40)
            {
                Hp.hp = 0;
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Алкоголь до добра не довел, уснул в баре, труп выкинули утром на улицу";
                return;
            }
            else if(Hp.hp <= 10 && Money.money < 100)
            {
                Hp.hp = 0;
                Money.money = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Оказалось нечем заплатить и отбиться";
                return;
            }
            else if(Sleep.sleep <= 40 && Money.money < 100)
            {
                Sleep.sleep = 0;
                Money.money = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Предложили отработать долг уборщиком, но сил было настолько мало, что даже этого не смог. Зарезали";
                return;
            }

            if(Hp.hp <= 10)
            {
                Hp.hp = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Подрался пьяным, умер от ножевого";
                return;
            }
            else if(Sleep.sleep <= 40)
            {
                Sleep.sleep = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Не успел увернуться от удара в драке";
                return;
            }
            else if(Money.money < 100)
            {
                Money.money = 0;
                Application.LoadLevel("GameOver");
                DeathLog.gameOver = 1;
                DeathLog.deathLog = "Оказалось нечем заплатить, забрали почки";
                return;
            }
            if(Money.money >= 100)
            {
                Money.money = Money.money - moneyDamage;
            }
            
            if(Vitality.vitality < 15)
            {
                Vitality.vitality = Vitality.vitality + vitalityBonus;
            }
            else
            {
                Vitality.vitality = 20;
            }

            if(Food.food < 80)
            {
                Food.food = Food.food + foodBonus;
            }
            else
            {
                Food.food = 100;
            }

            if(Alcohol.alcohol < 40)
            {
                Alcohol.alcohol = Alcohol.alcohol + alcoholBonus;
            }
            else
            {
                Alcohol.alcohol = 100;
            }

            if(Hp.hp > 10)
            {
                Hp.hp = Hp.hp - hpDamage;
            }

            if(Sleep.sleep > 40)
            {
                Sleep.sleep = Sleep.sleep - sleepDamage;
            }

            

            
        }
    }
}
