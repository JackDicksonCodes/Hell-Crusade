
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   bool gameOver = false;

   public void GameOver(){
       if(gameOver == false){
           gameOver = true;
           BackToMainMenu();
       }
   }

   void BackToMainMenu(){
       SceneManager.LoadScene("Main Menu");
   }
}
