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

        //move player character
        rb2d.AddForce(movement);
        rb2d.velocity = movement * speed;
        updateAnimator(moveHorizontal, movement);
    }

    void updateAnimator(float moveHorizontal, Vector2 movement) {
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
        if(moveHorizontal > 0) { 
            animator.SetBool(WALKING, true);
            previousAnimation = WALKING;

            //if player if facing the left
            if(Mathf.Approximately(transform.eulerAngles.y, 180.0f)) {
                //change the rotation.y to 0, face forward
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

        }// else if player is moving backward
        else if(moveHorizontal < 0) {
            animator.SetBool(WALKING, true);
            previousAnimation = WALKING;

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
