using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] GameObject PopUpObject;

    void Start()
    {
        PopUpObject.SetActive(false);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        PopUpObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PopUpObject.SetActive(true);
    }
}
