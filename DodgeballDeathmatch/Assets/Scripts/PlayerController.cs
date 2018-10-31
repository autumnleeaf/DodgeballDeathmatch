using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;
using DodgeballDeathmatch;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject dodgeballPrefab;

    public Player Player;

    [SerializeField] public string animWord;

    public Movement Movement;
    public float _movementSpeed;

    public int health = 100;
    public int team = 1;

    private GameObject _dodgeball;
    private Animator myAnimator;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        Player = new Player(team, _movementSpeed);
    }

    private void Update()
    {
        bool throwKeyDown = Input.GetKeyDown(Player.ShootKey);

        if (throwKeyDown && Player.BallCount > 0)
        {
            this.Throw();
        }
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw(Player.HoriztonalAxisName);
        var vertical = Input.GetAxisRaw(Player.VerticalAxisName);

        // Allows the speed component in the animation editor to see player speed
        myAnimator.SetFloat(animWord, Mathf.Abs(horizontal + vertical));

        // Changes game from frame movement to time movement
        var deltaTime = Time.deltaTime;

        // Set position to new calculated player postion
        transform.position = Player.CalculateNewPosition(transform.position, horizontal, vertical, deltaTime);
    }

    private void OnTriggerStay2D(Collider2D trigger)
    {
        var dodgeball = trigger.gameObject;

        if (dodgeball.GetType().ToString() == "BallController" && dodgeball.GetComponent<BallController>().getPickupStatus())
        {
            bool pickupKeyDown = Input.GetKeyDown(Player.PickupKey);

            if (pickupKeyDown)
            {
                Player.PickupBall();
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
        var dodgeball = collision.gameObject;


        if (dodgeball.GetComponent<Collider2D>() is CircleCollider2D)
        {
            var _ballController = dodgeball.GetComponent<BallController>();

            if(_ballController.getLiveStatus())
            {
                this.takeDamage(_ballController.damage);
                _ballController.SetLiveStatus(false);
            }
            StartCoroutine("ResetPhysics");
        }

        if(EnemyHealthBar.healthEnemy <= 0 || PlayerHealthBar.healthPlayer <= 0) 
        {
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        if (team == 1)
        {
            PlayerHealthBar.healthPlayer -= damage;
        }
        else
        {
            EnemyHealthBar.healthEnemy -= damage;
        }
    }

    void Throw()
    {
        _dodgeball = Instantiate(dodgeballPrefab) as GameObject;

        var direction = 1;
        if (team == 2) direction = -1;

        Vector3 instantiationPoint = new Vector3(2f, 0, 0);
        _dodgeball.transform.position = transform.TransformPoint(instantiationPoint);
        _dodgeball.GetComponent<BallController>().Throw(direction);

        Player.ThrowBall();
    }

    IEnumerator ResetPhysics()
    {
        yield return new WaitForSeconds(2f);

        Rigidbody2D _rbody = this.gameObject.GetComponent<Rigidbody2D>();

        this.transform.localRotation = Quaternion.identity;
        _rbody.velocity = new Vector2(0f, 0f);
        _rbody.angularVelocity = 0f;
    }
}
