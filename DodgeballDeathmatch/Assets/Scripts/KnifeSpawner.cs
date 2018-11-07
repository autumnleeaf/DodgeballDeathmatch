using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour 
{
    [SerializeField]
    float maxX;

    public GameObject knife;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    // FUnction to randomly spawn knives throughout the dodgeball court
    void SpawnKnife()
    {
        Instantiate(knife, transform.position, transform.rotation);
    }
}
