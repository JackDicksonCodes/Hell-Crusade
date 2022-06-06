using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellCircleBehaviour : MonoBehaviour
{
    public GameObject explosion;
    public GameObject kaboom;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(MiniExplosionSequence());
        StartCoroutine(ActualExplosion());
    }

    IEnumerator MiniExplosionSequence(){
        int i = 0;
        float x = 2.7f;
        float y = 2.7f;
        while(i < 2){
            yield return new WaitForSeconds(0.5f);
            GameObject explosion1 = Instantiate(explosion, calculateSpawnPos(x, y, transform.position), Quaternion.identity);
            GameObject explosion2 = Instantiate(explosion, calculateSpawnPos(-x, y, transform.position), Quaternion.identity);
            GameObject explosion3 = Instantiate(explosion, calculateSpawnPos(x, -y, transform.position), Quaternion.identity);
            GameObject explosion4 = Instantiate(explosion, calculateSpawnPos(-x, -y, transform.position), Quaternion.identity);
            i ++;
            x = x/2;
            y = y/2;
        }
    }

    IEnumerator ActualExplosion(){
        yield return new WaitForSeconds(1.5f);
        GameObject boom = Instantiate(kaboom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    

    private Vector3 calculateSpawnPos(float x, float y, Vector3 center){
        return new Vector3(center.x + x, center.y + y, center.z);
    }
}
