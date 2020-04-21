using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAnimatorController : MonoBehaviour {

	private const string WALKING = "Walking";
	private const string RUNNING = "Running";
	private const string CROUCHING = "Crouching";
	private const string JUMPING = "Jumping";
	private const string ATTACKING = "Attack";
	private const string DIEING = "Dieing";

	private Animator animator;
	private string previousAnimation;

	private BanditController banditController;

	float moveHorizontal;
	bool dead;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		previousAnimation = null;
		dead = false;
		banditController = GetComponent<BanditController>();

	}

    private void FixedUpdate()
    {
		if (dead)
			return;
		if (banditController.GetIsWalking())
		{
			animator.SetBool(ATTACKING, false);
			animator.SetBool(WALKING, true);
		}
		else if (banditController.GetIsAttacking()) {
			animator.SetBool(WALKING, false);
			animator.SetBool(ATTACKING, true);
        }
    }

    // Update is called once per frame
    void Update () {

	}

	public void DieAnimation()
	{
		animator.SetBool(WALKING, false);
		animator.SetBool(ATTACKING, false);
		animator.SetBool(DIEING, true);
		dead = true;
	}
}
