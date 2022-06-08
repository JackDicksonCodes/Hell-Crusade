using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToGoToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endGame());
    }

   IEnumerator endGame(){
       yield return new WaitForSeconds(41f);
       SceneManager.LoadScene("Main Menu");
   }
}
