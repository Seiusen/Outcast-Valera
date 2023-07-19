using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alcohol : MonoBehaviour
{
    public int maxAlcohol = 100;
    public static int alcohol;
    private Slider slider;
    

    void Start()
    {
        int[] array = new int[7] { 0, 5, 10, 15, 20, 25, 30 };
        int rand = array[Random.Range(0, array.Length)];
        alcohol = rand; // Тут нужно будет поменять!
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = alcohol;
    }
}