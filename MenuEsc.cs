using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEsc : MonoBehaviour
{
    
    void Update()
    {
        if(Input.GetKeyUp("escape"))
        {
            SaveSystem.SaveDataEsc();
            Application.LoadLevel("Menu");
        }
    }
}
