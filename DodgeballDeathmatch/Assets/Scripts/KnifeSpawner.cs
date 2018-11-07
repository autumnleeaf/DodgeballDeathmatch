using System.Collections;
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
        int rand = Random.Range(0, Knives.Length);

        Instantiate(Knives[rand], transform.position, transform.rotation);
    }
}
