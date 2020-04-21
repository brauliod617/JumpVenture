using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float totalHealth;
    public float currentHealth;
    public float healthLevel;
    public float meleeAttackDamage;

    private PlayerMovement playerMovement;
    private AnimatorController animatorController;

    public void Start()
    {
        //healthLevel = 1.0f;
        currentHealth = totalHealth * healthLevel;

        animatorController = GetComponent<AnimatorController>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public float GetMeleeAttackDamage() {
        return meleeAttackDamage;
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeavyBandit" && other.gameObject.GetComponent<BanditController>().GetIsAttacking())
        {
            Debug.Log(other.gameObject.tag);
            currentHealth -= other.gameObject.GetComponent<BanditController>().GetDamage() * Time.deltaTime;
            Debug.Log("Player HEalth: " + currentHealth);
            if (currentHealth <= 0)
            {
                animatorController.Die();
                playerMovement.Die();
            }
        }
    }
}
