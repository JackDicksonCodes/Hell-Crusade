using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEntrance : MonoBehaviour
{
    public string lastExitName;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("LastExitName") == lastExitName){
            PlayerPersistenceScript.instance.transform.position = transform.position;
            PlayerPersistenceScript.instance.transform.eulerAngles = transform.eulerAngles;
        } 
    }
}
