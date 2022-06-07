using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private Animator animator;
    public bool onFire;
    public float fireDuration;
    private float fireTick = 1f;
    private Rigidbody2D rigidbody;

    public AudioSource playerSounds;
    public AudioClip playerDeath;
    

    //This is for a health bar that appears on the UI
    public HealthBarScript healthBar;

    public void ReceiveDamage(int attackDamage){
        currentHealth -= attackDamage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0){
            animator.SetBool("Death", true);
            playerSounds.PlayOneShot(playerDeath);
            onFire = false;
            FindObjectOfType<PlayerMovement>().canMove = false;
            FindObjectOfType<PlayerShooting>().canShoot = false;
            rigidbody = GetComponent<Rigidbody2D>();
            StartCoroutine(GameOverRoutine());
        }
    }

    void FixedUpdate(){
        if(currentHealth <= 0){
        // animator.SetBool("Death", true);
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(GameOverRoutine());
        }
        if (onFire && fireTick <= 0){
            if(fireDuration > 0){
                StartCoroutine(fire());
                fireDuration -= Time.deltaTime;
                fireTick = 1f;
            }
            else{
                onFire = false;
            }
        }
        if(onFire && fireTick >= 0){
            fireTick -= Time.deltaTime;
        }



    }

    void Start(){
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
        animator = GetComponent<Animator>();
        onFire = false;
        fireDuration = 0;
    }

    public void heal(int healAmount){
        currentHealth += healAmount;
        if (currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    public void increaseMaxHealth(int increaseAmount){
        maxHealth += increaseAmount;
        healthBar.MaxHealth(maxHealth);
        heal(increaseAmount);

    }

    IEnumerator GameOverRoutine(){
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<GameManager>().GameOver();
    }

    IEnumerator fire(){
        yield return new WaitForSeconds(1f);
        ReceiveDamage(1);
        fireDuration -= 1f;
    }


}
