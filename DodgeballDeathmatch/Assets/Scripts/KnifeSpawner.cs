﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField]
    float maxX;

    public GameObject[] Knives;

	// Use this for initialization
	void Start () 
    {
        SpawnKnife();
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    // Function to randomly spawn knives throughout the dodgeball court
    void SpawnKnife()
    {
        // Statement to choose a random object
        int rand = Random.Range(0, Knives.Length);

        // Statement to chose where in the knives object will fall
        float randomX = Random.Range(-maxX, maxX);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(Knives[rand], randomPos, transform.rotation);
    }
}