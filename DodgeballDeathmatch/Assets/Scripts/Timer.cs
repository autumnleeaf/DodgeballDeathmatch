using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float time;
    private bool countdown = false;
    private bool visible = true;
    private bool canCount = false;

    private void Update()
    {
        if (time > 0.0f && canCount)
        {
            time -= Time.deltaTime;
            uiText.text = time.ToString("F");
        }
        else if (time <= 0.0f && countdown)
        {
            canCount = false;
            countdown = false;
            uiText.text = "0.00";
            time = 0.0f;
        }

        if(Input.GetKeyDown("t"))
        {
            if (countdown)
                if (canCount)
                    Stop();
                else
                    Resume();
            else
                Start();
        }
    }

    public void SetTime(float inputTime)
    {
        mainTimer = inputTime;
    }

    public float GetTime()
    {
        return time;
    }

    public void Start()
    {
        time = mainTimer;
        canCount = true;
        countdown = true;
    }

    public void Stop()
    {
        canCount = false;
    }

    public void Resume()
    {
        canCount = true;
    }

    public bool IsCountingDown()
    {
        return countdown;
    }

    public bool IsVisible()
    {
        return visible;
    }
}