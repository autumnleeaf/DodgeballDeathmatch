using NUnit.Framework;

[TestFixture]
public class TimerTest
{
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
        Assert.False(timer.visible);
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
}
