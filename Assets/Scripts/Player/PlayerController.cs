using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private const string WALKING = "Walking";
    private const string RUNNING = "Running";
    private const string CROUCHING = "Crouching";
    bool run;
    public bool secondJump;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    Rigidbody2D rb2d;
    private EdgeCollider2D edgeCollider2D;
    private Time currentTime;
    public float speed;
    public float runSpeed;
    public float maxSpeed;
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    [SerializeField] private LayerMask platofrmLayerMask;

    private Vector2 idlePosition;
    private string previousAnimation;


	void Start () {
        rb2d = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        edgeCollider2D = GetComponent<EdgeCollider2D>();
        secondJump = false;
      

        //gets current position which is idle
        idlePosition = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        previousAnimation = null;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        run = Input.GetKey(KeyCode.LeftShift);
        handleMovement();
        HandleJumping();
    }
    /***************************** MOVE & JUMP *******************************/
    void handleMovement() {
        float moveHorizontal = Input.GetAxis("Horizontal");


        float moveVertical = 0.0f;
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (rb2d == null)
            return;

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed) {
            return;
        }
        //move player character
        rb2d.AddForce(movement);
        if (run) {
            rb2d.AddForce(Vector2.right * movement * speed * runSpeed);
        }else {
            rb2d.AddForce(Vector2.right * movement * speed);
        }
        updateAnimator(moveHorizontal, movement, run);
    }

    private void HandleJumping()
    {
        if (Input.GetButtonDown("Jump") && (IsGrounded() || secondJump ))
        {
            Debug.Log("JUMPING");

            if (run)
                rb2d.AddForce(Vector2.up * (jumpVelocity + 50), ForceMode2D.Force);
            else
                rb2d.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Force);
            secondJump = !secondJump;
        }
        if (rb2d.velocity.y < 0)
        {
            rb2d.AddForce(Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        }

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(edgeCollider2D.bounds.center, edgeCollider2D.bounds.size, 0f,
        Vector2.down, .05f, platofrmLayerMask);
        return raycastHit2D.collider != null;
    }


    /************************************ ANIMATOR ****************************/
    void updateAnimator(float moveHorizontal, Vector2 movement, bool run) {
        if(animator == null) {
            print("Error in PlayerController.updateAnimator\n");
            return;
        }

        //turn of the previous animation if there was one and the movement is 
        //now idle position
        if(previousAnimation != null && movement == idlePosition) {
            animator.SetBool(previousAnimation, false);
            return;
        }
        //if player is moving forward
        if(moveHorizontal > 0){
            if (run){
                animator.SetBool(RUNNING, true);
                previousAnimation = RUNNING;
            }
            else {
                animator.SetBool(previousAnimation, false);
                animator.SetBool(WALKING, true);
                previousAnimation = WALKING;
            }

            //if player if facing the left
            if(Mathf.Approximately(transform.eulerAngles.y, 180.0f)) {
                //change the rotation.y to 0, face forward
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

        }// else if player is moving backward
        else if(moveHorizontal < 0) {
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
            if (Mathf.Approximately(transform.eulerAngles.y, 00.0f)){
                //change the rotation.y to 180, face backwords                
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
        else { //if player is not moving
            animator.SetBool(WALKING, false);
            previousAnimation = WALKING;
        }

    }

}
