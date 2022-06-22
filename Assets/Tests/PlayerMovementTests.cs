using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Player;

public class PlayerMovementTests
{

 
    [UnityTest]
    public IEnumerator MoveSuccess()
    {

        var movement = GetMovement();

        var expected = movement.transform.position + new Vector3(1, 0, 0) * movement.Speed * Time.deltaTime;

        movement.Move(new Vector3(1, 0, 0));
        yield return new WaitForEndOfFrame();


        Assert.AreEqual(expected, movement.transform.position);
    }


    [UnityTest]
    public IEnumerator StopMoveSuccess()
    {
        var movement = GetMovement();
        var expected = movement.transform.position;

        movement.StopMove();

        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(expected, movement.transform.position);
    }


    [UnityTest]
    public IEnumerator StartMoveSuccess()
    {
        var movement = GetMovement();
        movement.StopMove();
        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        movement.StartMove();

        var expected = movement.transform.position + new Vector3(1, 0, 0) * movement.Speed * Time.deltaTime;

        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(expected, movement.transform.position);
    }


    [UnityTest]
    public IEnumerator StopOnDialogStart()
    {
        var dialogObj = new GameObject();
        dialogObj.AddComponent<DialogSystem.DialogText>();

        var movement = GetMovement();
        var expected = movement.transform.position;

        DialogSystem.DialogText.Instance.InvokeStartDialogEvent();

        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(expected, movement.transform.position);
    }


    [UnityTest]
    public IEnumerator StartMoveOnDialogEnd()
    {
        var dialogObj = new GameObject();
        dialogObj.AddComponent<DialogSystem.DialogText>();

        var movement = GetMovement();

        DialogSystem.DialogText.Instance.InvokeStartDialogEvent();
        DialogSystem.DialogText.Instance.InvokeEndDialogEvent();

        var expected = movement.transform.position + new Vector3(1, 0, 0) * movement.Speed * Time.deltaTime;

        movement.Move(new Vector3(1, 0, 0));

        yield return new WaitForEndOfFrame();

        Assert.AreEqual(expected, movement.transform.position);
    }


    private PlayerMovement GetMovement()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<CharacterController>();

        return gameObject.AddComponent<PlayerMovement>();
    }
}
