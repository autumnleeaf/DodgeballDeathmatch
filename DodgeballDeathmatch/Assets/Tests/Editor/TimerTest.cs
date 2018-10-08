using NUnit.Framework;

[TestFixture]
public class TimerTest
{
    private bool? countdown;
    private object time;

    [Test]
    public void StartTimer()
    {
        var timer = new Timer();
        timer.SetTime(10);
        timer.Start();

        Assert.Greater(10.0, timer.GetTime());
    }

    [Test]
    public void StopTimer()
    {
        var timer = new Timer();

        timer.SetTime(10);
        timer.Start();
        timer.Stop();

        Assert.False(timer.IsCountingDown());
    }

    [Test]
    public void outOfTime()
    {
        var timer = new Timer();

        timer.SetTime(1.0f);
        timer.Start();

        System.Threading.Thread.Sleep(1000);

        Assert.False(timer.IsCountingDown());
        Assert.Equals(timer.GetTime(), 0.0);
    }
}