using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float speed = 16.0f;
    public Rigidbody2D rb;
    public Animator animator;
    public int damage = 5;

    private void Start()
    {
        animator.SetBool("Pickup", false);
    }

    public void Throw (int direction = 1) {
        rb.velocity = direction * transform.right * speed;
    }

    public bool getPickupStatus()
    {
        return animator.GetBool("Pickup");
    }

    public void SetPickupStatus(bool status)
    {
        animator.SetBool("Pickup", status);
        Debug.Log(animator.GetBool("Pickup"));
    }
}
