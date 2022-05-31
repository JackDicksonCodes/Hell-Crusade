using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageDoor : MonoBehaviour
{
    public string nextSceneName;


    public void MoveToNextStage(){
        SceneManager.LoadScene(nextSceneName);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Player")){
            Debug.Log("hit door");
            MoveToNextStage();
            }
        }
}