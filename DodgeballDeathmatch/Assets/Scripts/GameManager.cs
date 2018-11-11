using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;

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

        if (team == 0)
        {
            print("Both Lose");
        }
        else if (team == 1)
        {
            print("Player 2 Wins");
        }
        else if (team == 2)
        {
            print("Player 1 Wins");
        }
    }


}
