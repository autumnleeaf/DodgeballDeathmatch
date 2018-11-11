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
    [SerializeField] public string animWord;


    public Player Player;
    public Movement Movement;
    public float _movementSpeed;
    public static PlayerController instance;

    public int health = 100;
    public int team = 1;

    private GameObject _dodgeball;
    private Animator myAnimator;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        Player = new Player(transform.position, team, _movementSpeed);
    }
    public void Move ()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        bool pickupKeyDown = Input.GetKeyDown(Player.PickupKey);

        if (pickupKeyDown && Player.ReachableDodgeballs.Count > 0)
        {
            Player.PickupBall();
        }

        bool throwKeyDown = Input.GetKeyDown(Player.ShootKey);

        if (throwKeyDown && Player.BallCount > 0)
        {
            this.Throw();
        }

        if (Player.Health <= 0)
        {
            GameManager.instance.GameOver(team);
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw(Player.HoriztonalAxisName);
        var vertical = Input.GetAxisRaw(Player.VerticalAxisName);

        // Allows the speed component in the animation editor to see player speed
        myAnimator.SetFloat(animWord, Mathf.Abs(horizontal + vertical));

        // Set position to new calculated player postion
        transform.position = Player.CalculateNewPosition(transform.position, horizontal, vertical, Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger is CircleCollider2D)
        {
            var dodgeball = trigger.gameObject;

            dodgeball.GetComponent<BallController>().PickupStatus = true;

            Player.AddToReachable(dodgeball);
        }
    }

    private void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger is CircleCollider2D)
        {
            var dodgeball = trigger.gameObject;

            dodgeball.GetComponent<BallController>().PickupStatus = false;

            Player.RemoveFromReachable(dodgeball);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>() is CircleCollider2D)
        {
            var dodgeball = collision.gameObject;

            var _ballController = dodgeball.GetComponent<BallController>();

            if(_ballController.LiveStatus)
            {
                Player.TakeDamage(_ballController.Damage);

                _ballController.PickupStatus = false;
                _ballController.LiveStatus = false;

                StartCoroutine("ResetPhysics");
            }
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
