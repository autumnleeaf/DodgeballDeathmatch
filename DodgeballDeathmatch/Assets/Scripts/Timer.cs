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
                    stop();
                else
                    resume();
            else
                Start();
        }
    }

    public void setTime(float inputTime)
    {
        mainTimer = inputTime;
    }

    public float getTime()
    {
        return time;
    }

    public void Start()
    {
        time = mainTimer;
        canCount = true;
        countdown = true;
    }

    public void stop()
    {
        canCount = false;
    }

    public void resume()
    {
        canCount = true;
    }

    public bool isCountingDown()
    {
        return countdown;
    }

    public bool isVisible()
    {
        return visible;
    }
}