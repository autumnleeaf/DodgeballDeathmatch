using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Movement Movement;

    [SerializeField] private GameObject dodgeballPrefab;

    private GameObject _dodgeball;
    private Rigidbody2D _rbody;
    public float _movementSpeed;

    private void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        Movement = new Movement(_movementSpeed);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            this.Shoot();
        }
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var deltaTime = Time.deltaTime;

        transform.position += Movement.Calculate(horizontal, vertical, deltaTime);

    }

    void Shoot() {
        _dodgeball = Instantiate(dodgeballPrefab) as GameObject;
        _dodgeball.transform.position = transform.TransformPoint(Vector2.zero);
    }
}
