using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Components;

public class MovementComponentTests
{
    [UnityTest]
    public IEnumerator MoveSuccess()
    {
        var movement = CreateMovement();

        var expected = movement.transform.position + new Vector3(1, 0, 0) * movement.Speed * Time.deltaTime;

        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(expected, movement.transform.position);

        GameObject.Destroy(movement.gameObject);
    }


    [UnityTest]
    public IEnumerator UseGravitySuccess()
    {
        var movement = CreateMovement();
        movement.UseGravity = true;

        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        Assert.IsTrue(movement.transform.position.y < 0);

        GameObject.Destroy(movement.gameObject);
    }


    [UnityTest]
    public IEnumerator StopMoveSuccess()
    {
        var movement = CreateMovement();
        movement.StopMove();

        var expected = movement.transform.position;

        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(expected, movement.transform.position);

        GameObject.Destroy(movement.gameObject);
    }


    [UnityTest]
    public IEnumerator StartMoveSuccess()
    {
        var movement = CreateMovement();
        movement.StopMove();

        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        movement.StartMove();

        var expected = movement.transform.position + new Vector3(1, 0, 0) * movement.Speed * Time.deltaTime;

        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(expected, movement.transform.position);

        GameObject.Destroy(movement.gameObject);
    }


    private MovementComponent CreateMovement()
    {
        var gameObject = new GameObject().AddComponent<CharacterController>();
        var movement = gameObject.gameObject.AddComponent<MovementComponent>();
        movement.Speed = 100f;

        return movement;
    }
}
