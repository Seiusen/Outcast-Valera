using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem : MonoBehaviour
{
    public static int start;
    public static int loadCheck = 0;
    public static float x;
    public static float y;
    
    
    public void Start() {
        if(PlayerPrefs.HasKey("loadCheck"))
        {
            loadCheck = PlayerPrefs.GetInt("loadCheck");
        }

        
    }

    public void Update() {
        if(start == 1) 
        {
            DeleteDataEsc();
            start = 0;
        }   

        if(Input.GetKeyUp("5"))
        {
            SaveData();
        }

        if(Input.GetKeyUp("9") && loadCheck == 1)
        {
            LoadData();
        }

        if(Input.GetKeyUp("0"))
        {
            DeleteData();
        }
    }

    public static void SaveData()
    {
        PlayerPrefs.SetFloat("posX", Move.playerPosX);
        PlayerPrefs.SetFloat("posY", Move.playerPosY);
        PlayerPrefs.SetInt("HighscoreP", Highscore.hS);
        PlayerPrefs.SetInt("MoneyP", Money.money);
        PlayerPrefs.SetInt("PromotionP", Work.promotion);
        PlayerPrefs.SetInt("HpP", Hp.hp);
        PlayerPrefs.SetInt("FoodP", Food.food);
        PlayerPrefs.SetInt("DaysP", Days.days);
        PlayerPrefs.SetInt("VitalityP", Vitality.vitality);
        PlayerPrefs.SetInt("SleepP", Sleep.sleep);
        Debug.Log("SaveData");
        loadCheck = 1;
        PlayerPrefs.SetInt("loadCheck", loadCheck);
    }

    public static void SaveDataEsc()
    {
        PlayerPrefs.SetInt("MoneyPEsc", Money.money);
        PlayerPrefs.SetInt("PromotionPEsc", Work.promotion);
        PlayerPrefs.SetInt("HpPEsc", Hp.hp);
        PlayerPrefs.SetInt("FoodPEsc", Food.food);
        PlayerPrefs.SetInt("DaysPEsc", Days.days);
        PlayerPrefs.SetInt("VitalityPEsc", Vitality.vitality);
        PlayerPrefs.SetInt("SleepPEsc", Sleep.sleep);
        Debug.Log("SaveDataEsc");
    }

    public static void LoadData()
    {
        if(PlayerPrefs.HasKey("posX") || PlayerPrefs.HasKey("posY"))
        {
            x = PlayerPrefs.GetFloat("posX");
            y = PlayerPrefs.GetFloat("posY");
        }
        Highscore.hS = PlayerPrefs.GetInt("HighscoreP");
        Money.money = PlayerPrefs.GetInt("MoneyP");
        Work.promotion = PlayerPrefs.GetInt("PromotionP");
        Hp.hp = PlayerPrefs.GetInt("HpP");
        Food.food = PlayerPrefs.GetInt("FoodP");
        Days.days = PlayerPrefs.GetInt("DaysP");
        Vitality.vitality = PlayerPrefs.GetInt("VitalityP");
        Sleep.sleep = PlayerPrefs.GetInt("SleepP");
        Debug.Log("LoadData");
        
    }

    public static void LoadDataEsc()
    {
        if(PlayerPrefs.HasKey("MoneyPEsc") && PlayerPrefs.HasKey("PromotionPEsc") && PlayerPrefs.HasKey("HpPEsc") && PlayerPrefs.HasKey("FoodPEsc") && PlayerPrefs.HasKey("DaysPEsc") && PlayerPrefs.HasKey("VitalityPEsc") && PlayerPrefs.HasKey("SleepPEsc"))
        {
        Money.money = PlayerPrefs.GetInt("MoneyPEsc");
        Work.promotion = PlayerPrefs.GetInt("PromotionPEsc");
        Hp.hp = PlayerPrefs.GetInt("HpPEsc");
        Food.food = PlayerPrefs.GetInt("FoodPEsc");
        Days.days = PlayerPrefs.GetInt("DaysPEsc");
        Vitality.vitality = PlayerPrefs.GetInt("VitalityPEsc");
        Sleep.sleep = PlayerPrefs.GetInt("SleepPEsc");
        Debug.Log("LoadDataEsc");
        }
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        loadCheck = 0;
        Debug.Log("DeleteData");
    }

    public static void DeleteDataEsc()
    {
        LoadDataEsc();
        PlayerPrefs.DeleteKey("MoneyPEsc");
        PlayerPrefs.DeleteKey("PromotionPEsc");
        PlayerPrefs.DeleteKey("HpPEsc");
        PlayerPrefs.DeleteKey("FoodPEsc");
        PlayerPrefs.DeleteKey("DaysPEsc");
        PlayerPrefs.DeleteKey("VitalityPEsc");
        PlayerPrefs.DeleteKey("SleepPEsc");
    }
}
