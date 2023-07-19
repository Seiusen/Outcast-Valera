using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static int money;
    public Text moneyText;

    void Start()
    {
        money = 100; // Тут нужно будет поменять!
        moneyText = GetComponent<Text>();
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }
}
