using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public int maxHp = 100;
    public static int hp;
    private Slider slider;

    void Start()
    {
        int[] array = new int[9] { 100, 95, 90, 85, 80, 75, 70, 65, 60 };
        int rand = array[Random.Range(0, array.Length)];
        hp = rand; // Тут нужно будет поменять!
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        slider.value = hp;
    }
}
