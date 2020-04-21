using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAnimatorController : MonoBehaviour {

	private const string WALKING = "Walking";
	private const string RUNNING = "Running";
	private const string CROUCHING = "Crouching";
	private const string JUMPING = "Jumping";
	private const string ATTACKING = "Attack";

	private Animator animator;
	private string previousAnimation;

	private BanditController banditController;

	float moveHorizontal;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		previousAnimation = null;

		banditController = GetComponent<BanditController>();

	}

    private void FixedUpdate()
    {
        
        if (banditController.GetIsWalking())
        {
			animator.SetBool(WALKING, true);
        }
    }

    // Update is called once per frame
    void Update () {

	}
}
