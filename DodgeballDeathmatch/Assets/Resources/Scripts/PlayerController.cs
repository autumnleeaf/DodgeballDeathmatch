using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GameObject dodgeballPrefab;
    private GameObject _dodgeball;
    private int balls = 2;

    private void Start()
    {

        var _ball = PrefabUtility.InstantiatePrefab(
            Resources.Load("Prefabs/Dodgeball")
        ) as GameObject;

    }

    private void Update()
    {
        if (Input.GetKeyDown("space") == true && this.balls > 0)
        {
            this.Shoot();
        }
    }

    void Shoot() {
        _dodgeball = Instantiate(dodgeballPrefab) as GameObject;
        _dodgeball.transform.position = transform.TransformPoint(Vector2.zero);
        this.balls--;
    }
}
