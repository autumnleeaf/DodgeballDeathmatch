using UnityEngine;

public class Movement
{
    public float Speed;

    public Movement(float speed)
    {
        Speed = speed;
    }

    public Vector3 Calculate(float horizontal, float vertical, float deltaTime)
    {
        var deltaX = horizontal * Speed * deltaTime;
        var deltaY = vertical * Speed * deltaTime;

        return new Vector3(deltaX, deltaY, 0);
    }
}