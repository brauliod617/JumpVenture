using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float totalHealth;
    public float health;
    public float healthLevel;

    public float meleeAttackDamage;

    public void Start()
    {
        healthLevel = 1.0f;
        totalHealth = 100 * healthLevel;
        health = totalHealth;
        meleeAttackDamage = 2.0f;
    }
       

}
