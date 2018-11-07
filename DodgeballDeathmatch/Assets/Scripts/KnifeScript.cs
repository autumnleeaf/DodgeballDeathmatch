﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    // This function will be called whenever the knife collides with a 
    // player game object.
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Statement to decrease player score if it collides with the knife
        if (collision.gameObject.tag == "Player")
        {
            //Decrement Score

            Destroy(gameObject);
        }
        // Statement to destory the knife if the player avoids it
        else if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}