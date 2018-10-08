using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEditor;

public class BallTests {

    GameObject _dodgeball;

    [SetUp]
    public void Run_Before_Each_Test(){
        var ballPrefab = Resources.Load("Prefabs/Dodgeball");
        _dodgeball = PrefabUtility.InstantiatePrefab(ballPrefab) as GameObject;
        _dodgeball.transform.position = new Vector3(0, 0, 0);
    }

    [Test]
    public void Ball_Moves_Right_On_Default_Throw() 
    {
        _dodgeball.GetComponent<BallController>().Throw();

        var velocity = _dodgeball.GetComponent<BallController>().rb.velocity;

        Assert.Greater(velocity.x, 0);
    }

    [Test]
    public void Ball_Moves_Left_On_NegOne_Direction_Throw()
    {

        _dodgeball.GetComponent<BallController>().Throw(-1);

        var velocity = _dodgeball.GetComponent<BallController>().rb.velocity;

        Assert.Less(velocity.x, 0);
    }
}
