using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform bulletExit;

    public GameObject bulletObj;

    public BulletCount bulletCountUI;
    public ReloadUI reloadUI;

    public float bulletForce = 30f;

    private float fireRate = 0.2f;
    private float nextFire = 0f;
    private float reloadTime = 3f;

    private int maxBullets = 30;
    private int currentBullets;
    
    
    void Start(){
        currentBullets = maxBullets;
        bulletCountUI.currentBulletCount(currentBullets);
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting
        if(Input.GetButton("Fire1")&& Time.time > nextFire){
            while(Time.time > nextFire){
                nextFire = Time.time + fireRate;
                fire();
            }
        }

        //When R is pressed gun is reloaded
        if(Input.GetKeyDown(KeyCode.R)){
            currentBullets = 0;
            reloadUI.setTimer(reloadTime);
            bulletCountUI.toggleHideUI();//if not showing check inital state of isHidden in the UI element
            Invoke("reload", reloadTime);        
            }
    }

    void fire(){

        if(currentBullets != 0){
            GameObject bullet = Instantiate(bulletObj, bulletExit.position, bulletExit.rotation);
            Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
            body.AddForce(bulletExit.up * bulletForce, ForceMode2D.Impulse);
            currentBullets -= 1;
            bulletCountUI.currentBulletCount(currentBullets);
        }

    }
    void reload(){
        currentBullets = maxBullets;
        bulletCountUI.currentBulletCount(currentBullets);
        bulletCountUI.toggleHideUI();
    }

    
}
