using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

[TestFixture]
public class TimerTests
{
    private GameObject TimerObject;
    Timer Timer;

    [SetUp]
    public void Run_Before_Each_Test()
    {
        TimerObject = new GameObject();
        TimerObject.AddComponent<Text>();
        TimerObject.AddComponent<Timer>();

        Timer = TimerObject.GetComponent<Timer>();

        Timer.Current = Timer.CounterStart;
    }

    [Test]
    public void Timer_Set_To_Stated_Time()
    {
        int timeToSet = 10;
        Timer.Current = timeToSet;

        Assert.AreEqual(Timer.Current, timeToSet);
    }

    [Test]
    public void Timer_Does_Not_Go_Above_Max()
    {
        Timer.Current = Timer.CounterStart + 1;

        Assert.AreEqual(Timer.CounterStart, Timer.Current);
    }

    [Test]
    public void Timer_Does_Not_Go_Below_0()
    {
        Timer.Current = -1;

        Assert.AreEqual(Timer.Current, 0);
    }

    [Test]
    public void UpdateCounter_Does_Not_Work_If_Timer_Is_Off()
    {
        float elapsedSeconds = 1f;

        Timer.UpdateCounter(elapsedSeconds);

        var timerStart = Timer.Current;

        Timer.UpdateCounter(elapsedSeconds);

        Assert.AreEqual(timerStart, Timer.Current);
    }

    [Test]
    public void UpdateCounter_Counts_Down_Timer_When_Timer_On()
    {
        Timer.StartTimer();

        float elapsedSeconds = 1f;

        Timer.UpdateCounter(elapsedSeconds);

        var timerStart = Timer.Current;

        Timer.UpdateCounter(elapsedSeconds);

        Assert.Greater(timerStart, Timer.Current);
    }
}