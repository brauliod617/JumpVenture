using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditController : MonoBehaviour {

    public float moveSpeed;
	private float walkTime;
	private float waitTime;
	public BoxCollider2D walkZone;

	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;
	private bool isWalking;

	private Rigidbody2D rb2d;
	private SpriteRenderer spriteRenderer;
	private int walkDirection_int;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		walkDirection_int = Random.Range(0, 1);
		isWalking = true;

		minWalkPoint = walkZone.bounds.min;
		maxWalkPoint = walkZone.bounds.max;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Wander();
	}

	void Wander() {
		switch (walkDirection_int)
		{               
			case 0:
				spriteRenderer.flipX = true;
				if (transform.position.x > maxWalkPoint.x)
				{
					walkDirection_int = walkDirection_int == 1 ? 0 : 1;
					break;
				}
 				rb2d.AddForce(new Vector2(moveSpeed, 0));
				break;
			case 1:
				spriteRenderer.flipX = false;
				if (transform.position.x < minWalkPoint.x)
				{
					walkDirection_int = walkDirection_int == 1 ? 0 : 1;
					break;
				}
				rb2d.AddForce(new Vector2(-moveSpeed, 0));
				break;
		}
    }

	public int GetDirection() {
		return walkDirection_int;
    }
	public bool GetIsWalking() {
		return isWalking;
    }
}
