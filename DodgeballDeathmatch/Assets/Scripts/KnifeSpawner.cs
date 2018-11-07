using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField]
    float maxX;

    [SerializeField]
    float spawnInterval;

    public GameObject[] Knives;

	// Use this for initialization
	void Start () 
    {
        StartSpawningKnives();
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

        // Show knife on screen to interact with player
        Instantiate(Knives[rand], randomPos, transform.rotation);
    }

    // Call routine to create delay before spawning more knives
    IEnumerator SpawnKnives()
    {
        yield return new WaitForSeconds(2f);

        while(true)
        {
            SpawnKnife();

            yield return new WaitForSeconds(spawnInterval);

        }
    }

    public void StartSpawningKnives()
    {
        StartCoroutine("SpawnKnives");
    }

    public void StopSpawningKnives()
    {
        StopCoroutine("SpawnKnives");
    }

}
