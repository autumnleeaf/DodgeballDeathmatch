using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private GameObject dodgeballPrefab;
    private GameObject _dodgeball;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            this.Shoot();
        }
    }

    void Shoot() {
        _dodgeball = Instantiate(dodgeballPrefab) as GameObject;
        _dodgeball.transform.position = transform.TransformPoint(Vector2.zero);
    }
}
