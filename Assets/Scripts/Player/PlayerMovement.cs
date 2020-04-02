using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    AnimatorController animatorController;
    PlayerController playerController;

    float moveHorizontal;
    Vector2 movement;
    Vector2 idlePosition;
    public float speed;
    public float runSpeed;
    public float maxSpeed;
    public float jumpVelocity;
    bool run;
    bool secondJump;
    bool isIdle;

    // Use this for initialization
    void Start () {
        playerController = GetComponent<PlayerController>();
        animatorController = GetComponent<AnimatorController>();
        secondJump = false;

        //gets current position which is idle
        idlePosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        run = Input.GetKey(KeyCode.LeftShift);
        HandleMovement();
        HandleJumping();
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
        if (run)
        {
            playerController.rb2d.AddForce(Vector2.right * movement * speed * runSpeed);
        }
        else
        {
            playerController.rb2d.AddForce(Vector2.right * movement * speed);
        }
    }

    private void HandleJumping()
    {
        if (Input.GetButtonDown("Jump") && (playerController.IsGrounded() || secondJump))
        {
            if (run)
                playerController.rb2d.AddForce(Vector2.up * (jumpVelocity + 50), ForceMode2D.Force);
            else
                playerController.rb2d.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Force);
            secondJump = !secondJump;
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
}
