using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageExit : MonoBehaviour
{
    public string exitName;
    public string nextSceneName;


    public void MoveToNextStage(){
        PlayerPrefs.SetString("LastExitName", exitName);
        SceneManager.LoadScene(nextSceneName);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Player")){
            Debug.Log("hit door");
            MoveToNextStage();
            }
        }
}