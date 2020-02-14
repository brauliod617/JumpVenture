using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //read user input
    //if arrow keys pressed, 
    //move character positions accordingly 
    //start character animation
    // Use this for initialization


    private Rigidbody2D rb2d;
    public float test;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        	
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
        rb2d.velocity = movement * 5;
        test = movement.x;
    }
}
