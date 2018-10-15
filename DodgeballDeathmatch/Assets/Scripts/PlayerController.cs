using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject dodgeballPrefab;
    [SerializeField] public float player1maxLeft;
    [SerializeField] public float player1maxRight;
    [SerializeField] public float maxPosy;
    private GameObject _dodgeball;
    private Rigidbody2D _rbody;
    public Movement Movement;
    public float _movementSpeed;
    private Animator myAnimator;

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

        // Allows the speed component in the animation editor to see player speed
        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal + vertical));

        if (team == 2) {
            horizontal = Input.GetAxisRaw("Horizontal2");
            vertical = Input.GetAxisRaw("Vertical2");
        }

        // Changes game from frame movement to time movement
        var deltaTime = Time.deltaTime;

        // Calculates new position of character when moved
        transform.position += Movement.Calculate(horizontal, vertical, deltaTime);

        // STatements to restrict player 1 movement on the dodgeball court
        float xPos = Mathf.Clamp(transform.position.x, player1maxLeft, player1maxRight);
        float yPos = Mathf.Clamp(transform.position.y, -maxPosy, maxPosy);

        // New position of player 1 after restrictions on court are placed
        transform.position = new Vector3(xPos, yPos, transform.position.z);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision is CircleCollider2D)
        {
            string pickupKey = "v";
            if (team == 2) pickupKey = "/";

            if (Input.GetKeyDown(pickupKey) == true)
            {
                this.Pickup();
                Destroy(collision.gameObject);
            }
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
