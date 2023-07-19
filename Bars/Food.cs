using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    public int maxFood = 100;
    public static int food;
    private Slider slider;

    void Start()
    {
        int[] array = new int[9] { 90, 85, 80, 75, 70, 65, 60, 55, 50 };
        int rand = array[Random.Range(0, array.Length)];
        food = rand; // Тут нужно будет поменять!
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = food;
    }
}