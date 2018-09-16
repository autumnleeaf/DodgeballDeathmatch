using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using PlayerController;

public class CharacterMovementTest {

    [Test]
    public void NoVerticalMovementOnNoInput() {
        // Test to see if no input causes the character to stand still.
        PlayerController player = PlayerController();
        Vector2D startingPosition = player.position;
        player.MoveVertical(0);
        Assert.That(player.position == startingPosition);
    }

    [Test]
    public void NoHorizontalMovementOnNoInput()
    {
        // Test to see if no input causes the character to stand still.
        PlayerController player = PlayerController();
        Vector2D startingPosition = player.position;
        player.MoveHorizontal(0);
        Assert.That(player.position == startingPosition);
    }

    [Test]
    public void TestUpMovement() {
        // Test to see if 'w' moces a character up.
        PlayerController player = PlayerController();
        Vector2D startingPosition = player.position;
        player.MoveVertical(1);
        Assert.That(player.position.x > startingPosition.x);
    }

    [Test]
    public void TestDownMovement() {
        // Test to see if 's' moves a character down.
        PlayerController player = PlayerController();
        Vector2D startingPosition = player.position;
        player.MoveVertical(-1);
        Assert.That(player.position.x < startingPosition.x);
    }

    [Test]
    public void TestLeftMovement() {
        // Test to see if 'a' moves a character left.
        PlayerController player = PlayerController();
        Vector2D startingPosition = player.position;
        player.MoveHorizontal(-1);
        Assert.That(player.position.y < startingPosition.y);
    }

    [Test]
    public void TestRightMovement() {
        // Test to see if 'd' moves a character right.
        PlayerController player = PlayerController();
        Vector2D startingPosition = player.position;
        player.MoveHorizontal(1);
        Assert.That(player.position.y > startingPosition.y);
    }
}
