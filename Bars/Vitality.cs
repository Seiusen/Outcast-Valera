using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vitality : MonoBehaviour
{
    public int maxVitality = 20;
    public static int vitality;
    private Slider slider;

    void Start()
    {
        int[] array = new int[9] { 18, 16, 14, 12, 10, 8, 6, 4, 2 };
        int rand = array[Random.Range(0, array.Length)];
        vitality = rand; // Тут нужно будет поменять!
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = vitality;
    }
}