using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [HideInInspector]
    public EdgeCollider2D edgeCollider2D;
    [HideInInspector]
    public Rigidbody2D rb2d;
    [SerializeField] private LayerMask platofrmLayerMask;

    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        edgeCollider2D = GetComponent<EdgeCollider2D>();
	}

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(edgeCollider2D.bounds.center, edgeCollider2D.bounds.size, 0f,
        Vector2.down, .05f, platofrmLayerMask);
        return raycastHit2D.collider != null;
    }
}
