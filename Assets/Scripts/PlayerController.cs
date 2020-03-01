using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //read user input
    //if arrow keys pressed, 
    //move character positions accordingly 
    //start character animation
    // Use this for initialization
    private const string WALKING = "Walking";
    private const string RUNNING = "Running";
    private const string CROUCHING = "Crouching";

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb2d;
    public float speed;

    private Vector2 idlePosition;
    private string previousAnimation;


	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //gets current position which is idle
        idlePosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        previousAnimation = null;
	}
	
	// Update is called once per frame
	void Update () {
        handleMovement();
	}

    void handleMovement() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = 0.0f;
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (rb2d == null)
            return;

        rb2d.AddForce(movement);
        rb2d.velocity = movement * speed;
        updateAnimator(moveHorizontal, movement);
    }

    void updateAnimator(float moveHorizontal, Vector2 movement) {
        if(animator == null) {
            print("Error in PlayerController.updateAnimator\n");
            return;
        }

        if(previousAnimation != null && movement == idlePosition) {
            animator.SetBool(previousAnimation, false);
            return;
        }
        //if player is moving forward
        if(moveHorizontal > 0) { 
            animator.SetBool(WALKING, true);
            previousAnimation = WALKING;

            //if sprite was flipped, unflip it
            if (spriteRenderer.flipX == true)
                spriteRenderer.flipX = false;

        }else if(moveHorizontal < 0) {
            animator.SetBool(WALKING, true);
            previousAnimation = WALKING;

            //if sprite was flipped, unflip it
            if (spriteRenderer.flipX == false)
                spriteRenderer.flipX = true;
        }else {
            animator.SetBool(WALKING, false);
            previousAnimation = WALKING;
        }

    }

}
