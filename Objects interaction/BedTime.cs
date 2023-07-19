using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedTime : MonoBehaviour
{
    [SerializeField] public AudioSource bedSound;
    public float distance;
    int hpBonus = 90;
    int hpLowBonus = 30;
    int hpDamage = 10;
    int vitalityBonus = 3;
    int vitalityDamage = 3;
    int alcoholDamage = 30;
    int foodDamage = 40;
    int sleepBonus = 70;

    void Start()
    {
    }

    void Update()
    {
        distance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
        if (Input.GetKeyUp("space") && distance < 3f && Food.food > 0)
        {
            if(PlayerPrefs.HasKey("soundsVol"))
            {
                bedSound.volume = PlayerPrefs.GetFloat("soundsVol");
                bedSound.Play();
            }
            else
            {
                bedSound.volume = 1f;
                bedSound.Play();
            }
            Days.days++;

            if(Alcohol.alcohol >= 60)
            {
                if(Hp.hp > 10)
                {
                    Hp.hp = Hp.hp - hpDamage;
                    if(Alcohol.alcohol <= 70 ){
                        if(Alcohol.alcohol > 30)
                        {
                            Alcohol.alcohol = Alcohol.alcohol - alcoholDamage;
                        }
                        else if(Alcohol.alcohol <= 30)
                        {
                            Alcohol.alcohol = 0;
                        }
                        
                        if(Vitality.vitality > 17)
                        {
                            Vitality.vitality = 20;
                        }
                        else
                        {
                            Vitality.vitality = Vitality.vitality + vitalityBonus;
                        }
                    }
                    else if(Alcohol.alcohol > 70 && Vitality.vitality > 3)
                    {
                        Vitality.vitality = Vitality.vitality - vitalityDamage;
                        Alcohol.alcohol = Alcohol.alcohol - alcoholDamage;
                    }
                    else if(Alcohol.alcohol > 70 && Vitality.vitality < 3)
                    {
                        Vitality.vitality = 0;
                        Alcohol.alcohol = Alcohol.alcohol - alcoholDamage;
                        Application.LoadLevel("GameOver");
                        DeathLog.gameOver = 1;
                        DeathLog.deathLog = "Зачем я живу, если даже спать плохо? Валера повесился";
                        return;
                    }
                }
                else if(Hp.hp <= 10 && Vitality.vitality <=3)
                {
                    Hp.hp = 0;
                    Vitality.vitality = 0;
                    Application.LoadLevel("GameOver");
                    DeathLog.gameOver = 1;
                    DeathLog.deathLog = "Ноги отказали, спать не могу, жить не хочется. Валера наложил на себя руки";
                    return;
                }
                else if(Hp.hp <= 10){
                    Hp.hp = 0;
                    Application.LoadLevel("GameOver");
                    DeathLog.gameOver = 1;
                    DeathLog.deathLog = "Алкоголь до добра не довел, спился";
                    return;
                }
            }
            else if(Alcohol.alcohol < 30)
            {   
                if(Hp.hp > 10)
                {
                    Hp.hp = 100;
                }
                else
                {
                    Hp.hp = Hp.hp + hpBonus;
                }
                Alcohol.alcohol = 0;
                if(Vitality.vitality > 17)
                {
                    Vitality.vitality = 20;
                }
                else
                {
                    Vitality.vitality = Vitality.vitality + vitalityBonus;
                }
            }
            else if(Alcohol.alcohol < 60 && Alcohol.alcohol >= 30)
            {
                if(Alcohol.alcohol < 30)
                {
                    Alcohol.alcohol = 0;
                }
                else if(Alcohol.alcohol >= 30)
                {
                    Alcohol.alcohol = Alcohol.alcohol - alcoholDamage;
                }

                if(Hp.hp > 70)
                {
                    Hp.hp = 100;
                }
                else
                {
                    Hp.hp = Hp.hp + hpLowBonus;
                }

                if(Vitality.vitality > 17)
                {
                    Vitality.vitality = 20;
                }
                else
                {
                    Vitality.vitality = Vitality.vitality + vitalityBonus;
                }
            }

            if(Food.food < 40){
                Food.food = 0;
            }
            else
            {
                Food.food = Food.food - foodDamage;
            }

            if(Sleep.sleep > 30)
            {
                Sleep.sleep = 100;
            }
            else
            { 
                Sleep.sleep = Sleep.sleep + sleepBonus;
            }

            
        }
    }
}