using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenuButtons;


    public void playGame(){
        SceneManager.LoadScene("Level_1");
    }

    public void exitGame(){
        Application.Quit();
    }

    public void openOptions(){
        mainMenuButtons.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void closeOptions(){
        mainMenuButtons.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
