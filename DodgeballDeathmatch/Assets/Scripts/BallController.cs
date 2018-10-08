using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float speed = 16.0f;
    public Rigidbody2D rb;

    public void Throw (int direction = 1) {
        rb.velocity = direction * transform.right * speed;
    }
}
