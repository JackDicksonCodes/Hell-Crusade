using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniExplosionBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(miniExplosionSequence());
    }

    IEnumerator miniExplosionSequence(){
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
    
}
