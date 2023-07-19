using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Work : MonoBehaviour
{
    [SerializeField] public AudioSource workSound;
    public float distance;
    int alcoholDamage = 30;
    int foodDamage = 60;
    int vitalityDamage = 7;
    int sleepDamage = 70;
    public static int moneyBonus = 50;
    public static int promotion;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void OnTriggerExit2D(Collider2D boxCollider) {
        spriteRenderer.maskInteraction = SpriteMaskInteraction.None;

        if(PlayerPrefs.HasKey("soundsVol"))
        {
            workSound.volume = PlayerPrefs.GetFloat("soundsVol");
            workSound.Play();
        }
        else
        {
            workSound.volume = 1f;
            workSound.Play();
        }
    }

    void Start()
    {
        promotion = 0;
        spriteRenderer = GetComponent<SpriteRenderer> ();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        distance = Vector3.Distance(GameObject.Find("Player").transform.position, gameObject.transform.position);
        if (Input.GetKeyUp("space") && distance < 1.5f && Alcohol.alcohol < 50 && Sleep.sleep >= 70 && Food.food >= 60)
        { //Внимательно на еду! Возможно нужно будет поменять значение на меньшее
            

            if (Alcohol.alcohol <= 30)
            {
                Alcohol.alcohol = 0;
            }
            else
            {
                Alcohol.alcohol = Alcohol.alcohol - alcoholDamage;
            }
                
            Food.food = Food.food - foodDamage;
            Sleep.sleep = Sleep.sleep - sleepDamage;

            if(Vitality.vitality > 7)
            {
                Vitality.vitality = Vitality.vitality - vitalityDamage;
            }
            else
            {
                Vitality.vitality = 0;
            }

            if(promotion == 10)
            {
                moneyBonus = moneyBonus + 50;
                Money.money = Money.money + moneyBonus;
                promotion = 0;
            }
            else
            {
                Money.money = Money.money + moneyBonus;
                promotion++;
            }
            
            Open();
        }
    }

    private void Open() {
        spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

        if(PlayerPrefs.HasKey("soundsVol"))
        {
            workSound.volume = PlayerPrefs.GetFloat("soundsVol");
            workSound.Play();
        }
        else
        {
            workSound.volume = 1f;
            workSound.Play();
        }
    }
}