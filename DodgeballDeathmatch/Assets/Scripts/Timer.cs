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

    public bool stopwatch = false;

    private void Update()
    {
        if (canCount)
        {
            if (stopwatch)
            {
                time += Time.deltaTime;
            }
            else if (time > 0.0f)
            {
                time -= Time.deltaTime;
            }

            uiText.text = time.ToString("F");
        }
        else if (time <= 0.0f && countdown)
        {
            canCount = false;
            countdown = false;
            uiText.text = "0.00";
            time = 0.0f;
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

    public bool IsTimerActive()
    {
        return canCount;
    }

    public bool IsVisible()
    {
        return visible;
    }
}