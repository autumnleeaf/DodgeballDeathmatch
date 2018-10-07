using System;
using NUnit.Framework;

[TestFixture]
public class TimerTest
{
    private bool? countdown;
    private object time;

    [Test]
	public void startTimer()
    {
        var timer = new Timer();
        timer.setTime(10);
        timer.start();

        Assert.Greater(10, timer.time);
    }

    [Test]
    public void stopTimer()
    {
        var timer = new Timer();

        timer.setTime(10);
        timer.start();
        timer.stop();

        Assert.False(timer.countdown);
    }

    [Test]
    public void displayTimer()
    {
        var timer = new Timer();

        timer.display(true);
        Assert.True(timer.visible);

        timer.display(false);
        Assert.False(condition: timer.visible);
    }

    [Test]
    public void outOfTime()
    {
        var timer = new TimerTest();

        timer.setTime(1);
        timer.start();

        System.Threading.Thread.Sleep(1000);

        Assert.False(timer.countdown);
        Assert.Equals(timer.time, 0);
    }

    private void start()
    {
        throw new NotImplementedException();
    }

    private void setTime(int v)
    {
        throw new NotImplementedException();
    }

    private class Timer
    {
        internal int time;
        internal bool? countdown;
        internal bool? visible;

        public Timer()
        {
        }

        internal void display(bool v)
        {
            throw new NotImplementedException();
        }

        internal void setTime(int v)
        {
            throw new NotImplementedException();
        }

        internal void start()
        {
            throw new NotImplementedException();
        }

        internal void stop()
        {
            throw new NotImplementedException();
        }
    }
}
