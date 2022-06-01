using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    private Animator animator;
    

    //This is for a health bar that appears on the UI
    public HealthBarScript healthBar;

    public void ReceiveDamage(int attackDamage){
        currentHealth -= attackDamage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0){
            animator.SetBool("Death", true);
            StartCoroutine(GameOverRoutine());
        }
    }

    void FixedUpdate(){
         if(currentHealth <= 0){
            animator.SetBool("Death", true);
            StartCoroutine(GameOverRoutine());
        }
    }

    void Start(){
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    IEnumerator GameOverRoutine(){
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameManager>().GameOver();
    }

}
