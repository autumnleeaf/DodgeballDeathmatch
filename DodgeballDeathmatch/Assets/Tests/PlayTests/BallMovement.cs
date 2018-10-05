using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using NUnit.Framework;
using System.Collections;

public class BallMovement {

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator BallMovementWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame

        var ballPrefab = Resources.Load("Prefabs/Dodgeball");
        var _ball = PrefabUtility.InstantiatePrefab(ballPrefab) as GameObject;

        _ball.transform.position = new Vector3(0, 0, 0);


        var startPosition = _ball.transform.position;

        yield return null;
        yield return null;
        yield return null;

        Assert.AreNotEqual(startPosition, _ball.transform.position);
    }
}
