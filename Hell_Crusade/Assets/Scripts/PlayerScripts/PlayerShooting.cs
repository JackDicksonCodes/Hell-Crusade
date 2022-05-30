using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform bulletExit;

    public GameObject bulletObj;

    public float bulletForce = 30f;

    private float fireRate = 0.2f;
    private float nextFire = 0f;

    private int bullets = 30;
    

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButton("Fire1")&& Time.time > nextFire){
            while(Time.time > nextFire){
                nextFire = Time.time + fireRate;
                fire();
            }
        }

        if(Input.GetKeyDown(KeyCode.R)){
            bullets = 0;
            Invoke("reload", 3);        
            }
    }

    void fire(){

        if(bullets != 0){
            GameObject bullet = Instantiate(bulletObj, bulletExit.position, bulletExit.rotation);
            Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
            body.AddForce(bulletExit.up * bulletForce, ForceMode2D.Impulse);
            bullets -= 1;
        }
       

    }
    void reload(){
        bullets = 30;
    }

    
}
