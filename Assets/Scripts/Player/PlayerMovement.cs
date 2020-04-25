using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public ButtonManager leftButton;
    public ButtonManager rightButton;
    public ButtonManager jumpButton;
    public ButtonManager runButton;

    AnimatorController animatorController;
    PlayerController playerController;
    PlayerStats playerStats;
    float moveHorizontal;
    Vector2 movement;
    Vector2 idlePosition;
    public float speed;
    public float runSpeed;
    public float maxSpeed;
    public float jumpVelocity;
    public float runJumpBoost;
    public float secondJumpBoost;
    float runBoost;
    bool run;
    bool secondJump;
    bool isIdle;
    bool isDead;
    int jumps;
    int maxJumps;

    // Use this for initialization
    void Start () {
        playerController = GetComponent<PlayerController>();
        animatorController = GetComponent<AnimatorController>();
        secondJump = false;
        isDead = false;
        playerStats = GetComponent<PlayerStats>();
        maxJumps = 2;
        jumps = maxJumps;

        //gets current position which is idle
        idlePosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isDead)
            return;



        if (playerController.IsGrounded())
        {
            jumps = maxJumps;
        }

        if (jumpButton.IsPressed || Input.GetButtonDown("Jump"))
        {
            HandleJumping();
            jumpButton.IsPressed = false;
        }
        else if (leftButton.IsPressed )
        {
            moveHorizontal = -1;
        }
        else if (rightButton.IsPressed)
        {
            moveHorizontal = 1;
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            //moveHorizontal = 0;
        }


        //HandleJumping();
        HandleMovement();
        isIdle = (movement == idlePosition);
	}

    void HandleMovement()
    {
        //moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 0.0f;
        movement = new Vector2(moveHorizontal, moveVertical);

        if (runButton.IsPressed)
        {
            run = true;
            runBoost = (speed + runSpeed);
            Debug.Log("RUN");
        }
        else if (!runButton.IsPressed || Input.GetKey(KeyCode.LeftShift))
        {
            runBoost = speed;
            run = false;
        }

        if (playerController.rb2d == null)
            return;

        if (Mathf.Abs(playerController.rb2d.velocity.x) > maxSpeed)
        {
            return;
        }
 
        playerController.rb2d.AddForce(Vector2.right * movement * runBoost);

    }

    private void HandleJumping()
    {
        if ((playerController.IsGrounded() || ( jumps > 0 ) || playerStats.IsOnLava())) //( Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Keypad0) ) && 
        {
            Debug.Log("JUMP");
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerController.rb2d.AddForce(Vector2.up * (jumpVelocity + runJumpBoost + secondJumpBoost), ForceMode2D.Impulse);
            }
            else {
                playerController.rb2d.AddForce(Vector2.up * (jumpVelocity + secondJumpBoost), ForceMode2D.Impulse);
            }
            jumps--;
        }

    }

    public float GetMoveHorizontal() {
        return moveHorizontal;
    }

    public bool GetIsIdle() {
        return isIdle;
    }

    public bool GetRun() {
        return run;
    }

    public void Die() {
        isDead = true;
    }

    public void ResetJump() {
        jumps = maxJumps;
    }
    
}
