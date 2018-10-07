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
        timer.Start();

        Assert.Greater(10.0, timer.getTime());
    }

    [Test]
    public void stopTimer()
    {
        var timer = new Timer();

        timer.setTime(10);
        timer.Start();
        timer.stop();

        Assert.False(timer.isCountingDown());
    }

    [Test]
    public void outOfTime()
    {
        var timer = new Timer();

        timer.setTime(1.0f);
        timer.Start();

        System.Threading.Thread.Sleep(1000);

        Assert.False(timer.isCountingDown());
        Assert.Equals(timer.getTime(), 0.0);
    }
}