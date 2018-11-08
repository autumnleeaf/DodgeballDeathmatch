using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour 
{
    public int heartHealth = -10;

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
    void OnTriggerEnter2D(Collider2D collide)
    {
        // Statement to decrease player score if it collides with the knife
        if (collide.gameObject.tag == "Player" && collide is BoxCollider2D)
        {
            var Player = collide.gameObject.GetComponent<PlayerController>().Player;

            //Decrement Score
            Player.TakeDamage(heartHealth);
            Destroy(gameObject);
        }
        // Statement to destory the knife if the player avoids it
        else if (collide.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
