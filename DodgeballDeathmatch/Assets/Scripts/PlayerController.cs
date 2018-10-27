using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject dodgeballPrefab;
    [SerializeField] public float maxLeft;
    [SerializeField] public float maxRight;
    [SerializeField] public float maxPosy;
    [SerializeField] public string animWord;
    private GameObject _dodgeball;
    //rivate Rigidbody2D _rbody;
    public Movement Movement;
    private Animator myAnimator;
    public float _movementSpeed;

    public int health = 100;
    public int team = 1;
    public int balls = 5;

    private void Start()
    {
        //_rbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
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

        if (team == 2)
        {
            horizontal = Input.GetAxisRaw("Horizontal2");
            vertical = Input.GetAxisRaw("Vertical2");

        }


        // Allows the speed component in the animation editor to see player speed
        myAnimator.SetFloat(animWord, Mathf.Abs(horizontal + vertical));

        // Changes game from frame movement to time movement
        var deltaTime = Time.deltaTime;

        // Calculates new position of character when moved
        transform.position += Movement.Calculate(horizontal, vertical, deltaTime);

        // STatements to restrict player 1 movement on the dodgeball court
        float xPos = Mathf.Clamp(transform.position.x, maxLeft, maxRight);
        float yPos = Mathf.Clamp(transform.position.y, -maxPosy, maxPosy);

        // New position of player 1 after restrictions on court are placed
        transform.position = new Vector3(xPos, yPos, transform.position.z);


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

    private void OnTriggerStay2D(Collider2D trigger)
    {
        var dodgeball = trigger.gameObject;

        if (dodgeball.GetType().ToString() == "BallController" && dodgeball.GetComponent<BallController>().getPickupStatus())
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

    void Shoot()
    {
        _dodgeball = Instantiate(dodgeballPrefab) as GameObject;

        var direction = 1;
        if (team == 2) direction = -1;

        Vector3 instantiationPoint = new Vector3(2f, 0, 0);
        _dodgeball.transform.position = transform.TransformPoint(instantiationPoint);
        _dodgeball.GetComponent<BallController>().Throw(direction);

        this.balls--;
    }

    void Pickup()
    {
        this.balls++;
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
