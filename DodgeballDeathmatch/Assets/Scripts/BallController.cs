using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float speed = 16.0f;
    public Rigidbody2D rb;
    public bool leftball;


	// Use this for initialization
	void Start () {
        // Moves ball towards right
        rb.velocity = transform.right * speed;
        if (leftball) {
            rb.velocity *= -1;
        }
	}
}
