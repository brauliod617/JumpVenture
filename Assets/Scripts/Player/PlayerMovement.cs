using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

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
        Debug.Log("t4st");
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
        HandleJumping();
        HandleMovement();
        isIdle = (movement == idlePosition);
	}

    void HandleMovement()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 0.0f;
        movement = new Vector2(moveHorizontal, moveVertical);

        if (playerController.rb2d == null)
            return;

        if (Mathf.Abs(playerController.rb2d.velocity.x) > maxSpeed)
        {
            return;
        }
        //move player character
        playerController.rb2d.AddForce(movement);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerController.rb2d.AddForce(Vector2.right * movement * (speed + runSpeed));
        }
        else
        {
            playerController.rb2d.AddForce(Vector2.right * movement * speed);
        }
    }

    private void HandleJumping()
    {
        if (( Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Keypad0) ) && (playerController.IsGrounded() || ( jumps > 0 ) || playerStats.IsOnLava()) )
        {
            Debug.Log("Jump Pressed");
            Debug.Log("secondJump: "+ secondJump);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Debug.Log("RUN JUMP");
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
        return Input.GetKey(KeyCode.LeftShift);
    }

    public void Die() {
        isDead = true;
    }

    public void ResetJump() {
        jumps = maxJumps;
    }
    
}
