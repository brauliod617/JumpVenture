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
	private int walkDirection_int;
	private float walkCounter;
	private float waitCounter;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		//walkCounter = walkTime;
		//waitCounter = waitTime;
		ChooseDirection();

		minWalkPoint = walkZone.bounds.min;
		maxWalkPoint = walkZone.bounds.max;
		Debug.Log("minWalkPoint: " + minWalkPoint);
		Debug.Log("maxWalkPoint: " + maxWalkPoint);
	}
	
	// Update is called once per frame
	void Update () {
		Wander();
	}

	void ChooseDirection() {
		walkDirection_int = Random.Range(0, 1);
		isWalking = true;
		walkCounter = Random.Range(10, 25);
        waitCounter = Random.Range(1, 3);
		//Debug.Log("WaitCounter: " + waitCounter);
		//Debug.Log("Walk Counter: " + walkCounter);
    }

	void Wander() {
		if (isWalking)
		{
			Debug.Log("walk Direction: " + walkDirection_int);
			switch (walkDirection_int)
			{               
				case 0:
					if (transform.position.x > maxWalkPoint.x)
					{
						Debug.Log("passed max +x");
						walkDirection_int = walkDirection_int == 1? 0: 1;
						break;
					}
					Debug.Log("Move right");
					rb2d.AddForce(new Vector2(moveSpeed, 0));
					break;
				case 1:
					if (transform.position.x < minWalkPoint.x)
					{
						Debug.Log("passed min x");
						walkDirection_int = walkDirection_int == 1 ? 0 : 1;
                        
						break;
					}
					Debug.Log("Move left");
					rb2d.AddForce(new Vector2(-moveSpeed, 0));
					break;
			}
			//walkCounter -= Time.deltaTime;
			//Debug.Log("walkCounter -= Time.deltaTime: " + (walkCounter -= Time.deltaTime));
			//if (walkCounter <= 0)
			//{
			//	isWalking = false;
			//	//walkCounter = walkTime;
			//}

		}
		else {
			//waitCounter -= Time.deltaTime;
			//Debug.Log("waitCounter -= Time.deltaTime: " + (waitCounter -= Time.deltaTime));
			//rb2d.velocity = Vector2.zero;
			//if (waitCounter < 0) {
			//	ChooseDirection();
			//	//walkCounter = waitTime;
   //         }
        }
        
    }
}
