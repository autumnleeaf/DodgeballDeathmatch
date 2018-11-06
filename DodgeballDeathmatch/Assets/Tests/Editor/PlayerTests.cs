using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;
using DodgeballDeathmatch;

public class PlayerTests
{
    Player Player;

    [SetUp]
    public void Run_Before_Each_Test()
    {
        Player = new Player(Vector3.zero);
    }

    [Test]
    public void Player_Health_Starts_At_100() {
        int currentHealth = Player.Health;
        Assert.AreEqual(100, currentHealth);
    }

    [Test]
    public void Player_Takes_Specified_Damage()
    {
        int startingHealth = Player.Health;
        int damage = 7;

        Player.TakeDamage(damage);
        int currentHealth = Player.Health;

        Assert.AreEqual(damage, startingHealth - currentHealth);
    }
}
