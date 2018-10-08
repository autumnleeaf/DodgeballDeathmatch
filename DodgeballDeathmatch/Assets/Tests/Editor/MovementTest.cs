using NUnit.Framework;

public class MovementTest
{
    [Test]
    public void Moves_Along_X_Axis_For_Horizontal_Input()
    {
        Assert.AreEqual(1, new Movement(1).Calculate(1, 0, 1).x, 0.1f);
    }

    [Test]
    public void Moves_Along_Y_Axis_For_Horizontal_Input()
    {
        Assert.AreEqual(1, new Movement(1).Calculate(0, 1, 1).y, 0.1f);
    }
}
