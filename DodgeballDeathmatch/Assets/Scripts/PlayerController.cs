using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.UI;
using DodgeballDeathmatch;
using System.IO.Ports;

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
    public int bite ;


    private GameObject _dodgeball;
    private Animator myAnimator;
    static SerialPort sp = new SerialPort("COM3", 9600);

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        Player = new Player(transform.position, team, _movementSpeed);
        sp.Open();
        sp.ReadTimeout = 1;
    }
    public void Move()
    {
        if (this != null)
        {
            Destroy(this.gameObject);
        }

    }

    void Update()
    {
        bool pickupKeyDown = Input.GetKeyDown(Player.PickupKey);
        bool throwKeyDown = Input.GetKeyDown(Player.ShootKey);

        // If Controller is on assign based on controller
        if (sp.IsOpen && Player.Team == 2)
        {
            bite = sp.ReadByte();
            if (bite == 1 || pickupKeyDown)
            {
                pickupKeyDown = true;
            }
            if (bite == 2 || throwKeyDown)
            {
                throwKeyDown = true;
            }
        }

        if (pickupKeyDown && Player.ReachableDodgeballs.Count > 0)
        {
            Player.PickupBall();
        }

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

        // If controller is on, assign based on its inputs
        if (sp.IsOpen && Player.Team == 2)
        {



            switch (sp.ReadByte())
            {
                case 13: // up
                    vertical = 1;
                    break;
                case 12: // down
                    vertical = -1;
                    break;
                case 31: // right
                    horizontal = 1;
                    break;
                case 21: // left
                    horizontal = -1;
                    break;
                case 23: //left + up
                    horizontal = -1;
                    vertical = 1;
                    break;
                case 22: //left + down
                    horizontal = -1;
                    vertical = -1;
                    break;
                case 33: //right + up
                    horizontal = 1;
                    vertical = 1;
                    break;
                case 32: //right + down
                    horizontal = 1;
                    vertical = -1;
                    break;
            }
        }

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

            if (_ballController.LiveStatus)
            {
                dodgeball.GetComponent<BallController>().PickupStatus = false;

                Player.RemoveFromReachable(dodgeball);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Collider2D>() is CircleCollider2D)
        {
            var dodgeball = collision.gameObject;

            var _ballController = dodgeball.GetComponent<BallController>();

            if(_ballController.IsLive)
            {
                Player.TakeDamage(_ballController.Damage);

                _ballController.PickupStatus = false;
                _ballController.IsLive = false;

                StartCoroutine("ResetPhysics");
            }
        }
    }

    void Throw()
    {
        if (isPaused) return;
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