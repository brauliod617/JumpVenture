 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	PlayerController playerController;
	PlayerStats playerStats;
    public ButtonManager attackButton;

    bool melee;


    // Use this for initialization
    void Start () {
		playerController = GetComponent<PlayerController>();
		playerStats = GetComponent<PlayerStats>();
        melee = false;

    }

    private void FixedUpdate()
    {
        if (attackButton.IsPressed) {
            melee = true;
        }
        
    }


    /***************************** MELEE ATTACK ******************************/

    void AttackEnd()
    {
        melee = false;
    }

    public bool GetMelee() {
        return melee;
    }
}
