using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditController : MonoBehaviour {

	public Transform target;
    public float moveSpeed;
	private float walkTime;
	private float waitTime;
	public BoxCollider2D walkZone;
	public int attackSpeed;
	public float banditDamage;
	public float maxWalkSpeed;


	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;
	private bool isWalking;
	private bool isAttacking;
    private bool inAttackRange;
	private bool isDead;


	private Rigidbody2D rb2d;
	private SpriteRenderer spriteRenderer;
	private int walkDirection_int;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		walkDirection_int = Random.Range(0, 1);
		isWalking = true;
		inAttackRange = false;
		isDead = false;

		minWalkPoint = walkZone.bounds.min;
		maxWalkPoint = walkZone.bounds.max;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isDead)
			return;

		if (!isAttacking)
			Wander();
		else
		    isWalking = false;
	}

    private void OnTriggerStay2D(Collider2D other)
    {
		if (isDead)
			return;
		if (other.gameObject.tag == "Player") {
			isAttacking = true;
			if (!inAttackRange) {
				if (target.transform.position.x > transform.position.x)
				{
					spriteRenderer.flipX = true;
					if (transform.position.x < maxWalkPoint.x)
					{
                        if(Mathf.Abs(rb2d.velocity.x) < maxWalkSpeed)
						    rb2d.AddForce(new Vector2(moveSpeed, 0));
					}
				}
				else if (target.transform.position.x < transform.position.x)
				{
					spriteRenderer.flipX = false;
                    if (transform.position.x > minWalkPoint.x)
                    {
						if (Mathf.Abs(rb2d.velocity.x) < maxWalkSpeed)
							rb2d.AddForce(new Vector2(-moveSpeed, 0));
                    }
                }
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
		if (isDead)
			return;
		if (other.gameObject.tag == "Player") {
			isAttacking = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
		if (isDead)
			return;
		if (other.gameObject.tag == "Player") {
			inAttackRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
		if (isDead)
			return;
		if (other.gameObject.tag == "Player") {
			inAttackRange = false;
		}
    }

    void Wander() {
		isWalking = true;
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
	public bool GetIsAttacking() {
		if (isDead)
			return false;
		return inAttackRange;
    }

	public void Die() {
		isDead = true;
		GetComponent<CapsuleCollider2D>().isTrigger = true;
    }
	public float GetDamage()
	{
		return banditDamage;

	}
}
