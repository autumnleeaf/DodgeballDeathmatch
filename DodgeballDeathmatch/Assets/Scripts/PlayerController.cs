using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour {
    public Movement Movement;

    [SerializeField] private GameObject dodgeballPrefab;

    private GameObject _dodgeball;
    private int balls = 2;

    private Rigidbody2D _rbody;
    public float _movementSpeed;

    private void Start() {
        _rbody = GetComponent<Rigidbody2D>();
        Movement = new Movement(_movementSpeed);
    }

    private void Update() {
        if (Input.GetKeyDown("space") == true && this.balls > 0)
        {
            this.Shoot();
        }
    }

    private void FixedUpdate() {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var deltaTime = Time.deltaTime;

        transform.position += Movement.Calculate(horizontal, vertical, deltaTime);

    }

    void Shoot() {
        _dodgeball = Instantiate(dodgeballPrefab) as GameObject;
        _dodgeball.transform.position = transform.TransformPoint(Vector2.zero);
        this.balls--;
    }
}
