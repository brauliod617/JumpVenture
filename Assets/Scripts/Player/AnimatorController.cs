using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour {

    private const string WALKING = "Walking";
    private const string RUNNING = "Running";
    private const string CROUCHING = "Crouching";
    private const string JUMPING = "Jumping";
    private const string ATTACKING = "Attack";
    private const string DIEING = "Dieing";

    private Animator animator;
    private string previousAnimation;

    private PlayerController playerController;
    private PlayerAttack playerAttack;
    private PlayerMovement playerMovement;
    private PlayerStats playerStats;

    bool melee;
    bool run;
    bool isIdle;
    bool isDead;

    float moveHorizontal;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        previousAnimation = null;
        playerController = GetComponent<PlayerController>();
        playerAttack = GetComponent<PlayerAttack>();
        playerMovement = GetComponent<PlayerMovement>();
        playerStats = GetComponent<PlayerStats>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isDead)
            return;
        melee = playerAttack.GetMelee();
        run = playerMovement.GetRun();
        isIdle = playerMovement.GetIsIdle();
        moveHorizontal = playerMovement.GetMoveHorizontal();
        UpdateAnimator();
	}

    /************************************ ANIMATOR ****************************/
    public void Die() {
        animator.SetBool(previousAnimation, false);
        animator.SetTrigger("Die");
        isDead = true;
    }


    private void UpdateAnimator()
    {
        if (animator == null)
        {
            print("Error in PlayerController updateAnimator\n");
            return;
        }
        //if player is attacking
        if (melee)
        {
            animator.SetBool(previousAnimation, false);
            animator.SetTrigger(ATTACKING);
            //animator.SetBool(ATTACKING, true);
            //previousAnimation = ATTACKING;
            return;
        }

        //if player is in the air
        if ((!playerController.IsGrounded()))
        {
            if (!playerStats.IsOnLava())
            {
                animator.SetBool(previousAnimation, false);
                animator.SetBool(JUMPING, true);
                previousAnimation = JUMPING;
                return;
            }
        }

        //TODO: find a better way to do this, for some reason jumping stays true
        //in some cases, this is a hack to fix it
        if (playerController.IsGrounded() && animator.GetBool(JUMPING))
        {
            animator.SetBool(JUMPING, false);
        }

        //turn of the previous animation if there was one and the movement is 
        //now idle position
        if (previousAnimation != null && isIdle)
        {
            animator.SetBool(previousAnimation, false);
            return;
        }

        //if player is moving forward
        if (moveHorizontal > 0)
        {
            if (run)
            {
                animator.SetBool(previousAnimation, false);
                animator.SetBool(RUNNING, true);
                previousAnimation = RUNNING;
            }
            else
            {
                animator.SetBool(previousAnimation, false);
                animator.SetBool(WALKING, true);
                previousAnimation = WALKING;
            }

            //if player if facing the left
            if (Mathf.Approximately(transform.eulerAngles.y, 180.0f))
            {
                //change the rotation.y to 0, face forward
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

        }// else if player is moving backward
        else if (moveHorizontal < 0)
        {
            if (run)
            {
                animator.SetBool(RUNNING, true);
                previousAnimation = RUNNING;
            }
            else
            {
                animator.SetBool(previousAnimation, false);
                animator.SetBool(WALKING, true);
                previousAnimation = WALKING;
            }

            //if player is facing the right
            if (Mathf.Approximately(transform.eulerAngles.y, 00.0f))
            {
                //change the rotation.y to 180, face backwords                
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else
        { //if player is not moving
            animator.SetBool(WALKING, false);
            previousAnimation = WALKING;
        }
    }

}
