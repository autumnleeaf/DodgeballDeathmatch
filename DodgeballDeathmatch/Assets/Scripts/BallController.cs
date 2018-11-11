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

    public bool IsLive
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
        var player = GameObject.Find("Player");
        var enemy = GameObject.Find("Enemy");

        Physics2D.IgnoreCollision(player.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>(), !IsLive);
        Physics2D.IgnoreCollision(enemy.GetComponent<BoxCollider2D>(), GetComponent<Collider2D>(), !IsLive);


        // Makes sure if ball is set to dead, then ball is stopped
        if (!IsLive)
        {
            rb.velocity *= 0;
        }
        // Makes sure if ball is stopped, then ball is set to dead
        if (Math.Abs(Vector2.Distance(rb.velocity, Vector2.zero)) < 0.01f){
            IsLive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag.Equals("End Wall"))
        {
            IsLive = false;
        }

        if (target.gameObject.tag.Equals("Ball"))
        {
            IsLive = true;
        }
    }

    public void Throw (int direction = 1) {
        rb.velocity = direction * transform.right * throwSpeed;
        IsLive = true;
    }

}
