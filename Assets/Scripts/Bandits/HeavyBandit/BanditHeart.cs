using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditHeart : MonoBehaviour {

	public GameObject heavyBandit;
	public float banditHealth;
	private bool dead;
    // Use this for initialization
	void Start () {
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (dead)
			return;
		transform.position = heavyBandit.transform.position;

		if (banditHealth <= 0) {
			heavyBandit.GetComponent<BanditAnimatorController>().DieAnimation();
			heavyBandit.GetComponent<BanditController>().Die();
			dead = true;
        }
	}

    private void OnTriggerStay2D(Collider2D other)
    {
		if (dead)
			return;
		transform.position = heavyBandit.transform.position;
		if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerAttack>().GetMelee() && !dead) {
			banditHealth -= other.gameObject.GetComponent<PlayerStats>().GetMeleeAttackDamage() * Time.deltaTime;
        }
	}
}
