using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPopUp : MonoBehaviour
{
    public Text moneyText;

    void Start()
    {
        moneyText = GetComponent<Text>();
    }

    void Update()
    {
        moneyText.text = Work.moneyBonus.ToString();
    }
}
