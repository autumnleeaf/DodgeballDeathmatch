using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;

public class PlayerTests
{
    GameObject _player;

    [SetUp]
    public void Run_Before_Each_Test()
    {
        var playerPrefab = Resources.Load("Prefabs/Player");
        _player = PrefabUtility.InstantiatePrefab(playerPrefab) as GameObject;
        _player.transform.position = new Vector3(0, 0, 0);
    }

    [Test]
    public void Player_Health_Starts_At_100() {
        int currentHealth = _player.GetComponent<PlayerController>().health;
        Assert.AreEqual(100, currentHealth);
    }
}
