using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public void PlayGame()
    {
        SaveSystem.start = 1;
        Application.LoadLevel("Game");
    }

    public void ExitGame()
    {
        SaveSystem.DeleteDataEsc();
        Application.Quit();
    }

    public void Settings()
    {
        Application.LoadLevel("Settings");
    }

    public void Menu()
    {
        Application.LoadLevel("Menu");
    }

    void Start() {

    }

    void Update()
    {   
        if(Input.GetKeyUp("escape"))
        {
            SaveSystem.start = 1;
            Application.LoadLevel("Game");
        }
    }
}
