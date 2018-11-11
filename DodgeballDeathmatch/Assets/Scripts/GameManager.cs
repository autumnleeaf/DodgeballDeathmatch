using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    public Movement Movement;
    float speed = 0f;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    public void GameOver(int team)
    {
        print("GameOver()");
        print(team);

        // Stop objects from spawning
        ObjectSpawner.instance.StopSpawning();

        // Stop players from moving
        PlayerController.instance.Move();

        switch (team)
        {
            case 0:
                print("Both Lose");
                break;
            case 1:
                Timer.instance.StopTimer();
                print("Player 2 Wins");
                break;
            case 2:
                Timer.instance.StopTimer();
                print("Player 1 Wins");
                break;
        }
    }


}
