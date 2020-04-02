 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	PlayerController playerController;
	PlayerStats playerStats;

    bool melee;


    // Use this for initialization
    void Start () {
		playerController = GetComponent<PlayerController>();
		playerStats = GetComponent<PlayerStats>();
        melee = false;

    }

    private void FixedUpdate()
    {
        HandleMeleeAttack();
    }


    /***************************** MELEE ATTACK ******************************/
    void HandleMeleeAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            melee = true;
        }
    }

    void AttackEnd()
    {
        melee = false;
    }

    public bool GetMelee() {
        return melee;
    }
}
