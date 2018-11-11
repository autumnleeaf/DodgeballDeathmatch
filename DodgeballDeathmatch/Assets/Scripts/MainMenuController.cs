using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    // To start playing the game when the play button is selceted
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Rules()
    {
        SceneManager.LoadScene("RulesMenu");
    }

    // To exit the game when the exit button is selected
    public void Exit()
    {
        Application.Quit();
    }

   
}
