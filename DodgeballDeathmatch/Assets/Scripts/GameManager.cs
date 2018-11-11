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
    public GameObject pausePanel;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is already paused, we can resume
            if (PlayerController.isPaused)
            {
                Resume();
                return;
            }

            // Stop objects from spawning
            ObjectSpawner.instance.StopSpawning();

            // Stop the players being controlled
            PlayerController.isPaused = true;

            // Stop the timer
            Timer.instance.StopTimer();

            // Show the pause panel
            pausePanel.SetActive(true);
        }
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

    public void Resume()
    {
        // Resume everything and hide the panel
        Timer.instance.timerOn = true;
        ObjectSpawner.instance.StartSpawning();
        PlayerController.isPaused = false;
        pausePanel.SetActive(false);
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
