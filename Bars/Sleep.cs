using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sleep : MonoBehaviour
{
    public int maxSleep = 100;
    public static int sleep;
    private Slider slider;

    void Start()
    {
        int[] array = new int[7] { 100, 95, 90, 85, 80, 75, 70 };
        int rand = array[Random.Range(0, array.Length)];
        sleep = rand; // Тут нужно будет поменять!
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = sleep;
    }
}