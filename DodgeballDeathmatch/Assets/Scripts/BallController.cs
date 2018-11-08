using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float throwSpeed = 16.0f;
    public Rigidbody2D rb;
    public Animator animator;
    public int Damage = 5;

    public bool PickupStatus {
        get {
            return animator.GetBool("Pickup");
        }

        set {
            animator.SetBool("Pickup", value);
        }
    }

    public bool LiveStatus
    {
        get
        {
            return animator.GetBool("LiveBall");
        }

        set
        {
            animator.SetBool("LiveBall", value);
        }
    }

    private void Update()
    {
        // Makes sure if ball is set to dead, then ball is stopped
        if (!LiveStatus)
        {
            rb.velocity *= 0;
        }
        // Makes sure if ball is stopped, then ball is set to dead
        if (Math.Abs(Vector2.Distance(rb.velocity, Vector2.zero)) < 0.01f){
            LiveStatus = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag.Equals("End Wall") == true)
        {
            LiveStatus = false;
        }
    }

    public void Throw (int direction = 1) {
        rb.velocity = direction * transform.right * throwSpeed;
        LiveStatus = true;
    }

}
