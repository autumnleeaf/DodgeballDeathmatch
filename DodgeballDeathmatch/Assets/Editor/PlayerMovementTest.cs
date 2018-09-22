using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using PlayerController;

public class PlayerMovementTest
{

    [Test]
    public void NoVerticalMovementOnNoInput()
    {
        // Test to see if no input causes the character to stand still.
        var player = new PlayerController();
        Vector2 startingPosition = player.position;
        player.MoveVertical(0);
        Assert.That(player.position == startingPosition);
    }

    [Test]
    public void NoHorizontalMovementOnNoInput()
    {
        // Test to see if no input causes the character to stand still.
        var player = new PlayerController();
        Vector2 startingPosition = player.position;
        player.MoveHorizontal(0);
        Assert.That(player.position == startingPosition);
    }

    [Test]
    public void TestUpMovement()
    {
        // Test to see if 'w' moces a character up.
        var player = new PlayerController();
        Vector2 startingPosition = player.position;
        player.MoveVertical(1);
        Assert.That(player.position.x > startingPosition.x);
    }

    [Test]
    public void TestDownMovement()
    {
        // Test to see if 's' moves a character down.
        var player = new PlayerController();
        Vector2 startingPosition = player.position;
        player.MoveVertical(-1);
        Assert.That(player.position.x < startingPosition.x);
    }

    [Test]
    public void TestLeftMovement()
    {
        // Test to see if 'a' moves a character left.
        var player = new PlayerController();
        Vector2 startingPosition = player.position;
        player.MoveHorizontal(-1);
        Assert.That(player.position.y < startingPosition.y);
    }

    [Test]
    public void TestRightMovement()
    {
        // Test to see if 'd' moves a character right.
        var player = new PlayerController();
        Vector2 startingPosition = player.position;
        player.MoveHorizontal(1);
        Assert.That(player.position.y > startingPosition.y);
    }
}

