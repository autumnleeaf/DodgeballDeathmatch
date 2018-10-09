﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject dodgeballPrefab;
    private GameObject _dodgeball;
    private Rigidbody2D _rbody;
    public Movement Movement;
    public float _movementSpeed;

    public int health = 100;
    public int team = 1;
    public int balls = 5;

    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        Movement = new Movement(_movementSpeed);
    }

    private void Update()
    {
        string shootKey = "c";
        if (team == 2) shootKey = ".";

        if (Input.GetKeyDown(shootKey) == true && this.balls > 0)
        {
            this.Shoot();
        }
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        if(team == 2) {
            horizontal = Input.GetAxisRaw("Horizontal2");
            vertical = Input.GetAxisRaw("Vertical2");
        }

        var deltaTime = Time.deltaTime;

        transform.position += Movement.Calculate(horizontal, vertical, deltaTime);

    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

    private void OnTriggerStay2D(Collider2D trigger)
    {
        var dodgeball = trigger.gameObject;

        if (dodgeball.GetComponent<BallController>().getPickupStatus())
        {
            string pickupKey = "v";
            if (team == 2) pickupKey = "/";

            if (Input.GetKeyDown(pickupKey) == true)
            {
                this.Pickup();
                Destroy(dodgeball);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        var dodgeball = trigger.gameObject;

        if (trigger is CircleCollider2D)
        {
            dodgeball.GetComponent<BallController>().SetPickupStatus(true);
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        var dodgeball = trigger.gameObject;

        if (trigger is CircleCollider2D)
        {
            dodgeball.GetComponent<BallController>().SetPickupStatus(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var _ball = collision.gameObject;

        if (_ball.GetComponent<Collider2D>() is CircleCollider2D)
        {
            var _ballController = _ball.GetComponent<BallController>();
            this.takeDamage(_ballController.damage);
        }

        if(health <= 0) {
            Destroy(this.gameObject);
        }
    }

    void Shoot()
    {
        _dodgeball = Instantiate(dodgeballPrefab) as GameObject;

        var direction = 1;
        if (team == 2) direction = -1;

        Vector3 instantiationPoint = new Vector3(.25f * direction, 0, 0);
        _dodgeball.transform.position = transform.TransformPoint(instantiationPoint);
        _dodgeball.GetComponent<BallController>().Throw(direction);

        this.balls--;
    }

    void Pickup()
    {
        this.balls++;
    }
}
