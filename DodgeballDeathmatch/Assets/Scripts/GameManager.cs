using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    public GameObject gameOverPanel0;
    public GameObject gameOverPanel1;
    public GameObject gameOverPanel2;

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
        // Stop objects from spawning
        ObjectSpawner.instance.StopSpawning();

        // Stop players from moving
        PlayerController.instance.Move();

        switch (team)
        {
            case 0:
                gameOverPanel0.SetActive(true);
                break;
            case 1:
                Timer.instance.StopTimer();
                gameOverPanel2.SetActive(true);
                break;
            case 2:
                Timer.instance.StopTimer();
                gameOverPanel1.SetActive(true);
                break;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }


}
