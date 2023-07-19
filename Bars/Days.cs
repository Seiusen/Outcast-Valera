using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Days : MonoBehaviour
{
    public static int days;
    public Text daysText;

    void Start()
    {
        days = 0;
        daysText = GetComponent<Text>();
    }

    void Update()
    {
        daysText.text = "Day " + days.ToString();
    }
}
