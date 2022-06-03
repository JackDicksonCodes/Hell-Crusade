using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject menuButtons;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused == true){
                resume();
            } else {
                pause();
            }
        }
    }

    public void resume(){
        closeOptions();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void pause(){
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void toMainMenu(){
        resume();
        SceneManager.LoadScene("Main Menu");
    }

    public void openOptions(){
        menuButtons.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void closeOptions(){
        optionsMenu.SetActive(false);
        menuButtons.SetActive(true);
    }
}
