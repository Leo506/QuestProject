using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Player;
using UnityEngine.InputSystem;

public class PlayerMovementTests : InputTestFixture
{
    [UnityTest]
    public IEnumerator MoveForwardSuccess()
    {
        var movement = CreateMovement();

        var input = new PlayerInput();
        input.Player.Enable();

        Time.timeScale = 20;

        var expected = movement.transform.position + Vector3.forward * 20 * movement.Speed * Time.fixedDeltaTime;

        for (int i = 0; i < 20; i++)
        {
            PressKeyboardKey('w');
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        Time.timeScale = 1;

        Assert.AreEqual(expected, movement.transform.position);
    }

    [UnityTest]
    public IEnumerator MoveBackSuccess()
    {
        var movement = CreateMovement();

        var input = new PlayerInput();
        input.Player.Enable();

        Time.timeScale = 20;

        var expected = movement.transform.position + Vector3.back * 20 * movement.Speed * Time.fixedDeltaTime;

        for (int i = 0; i < 20; i++)
        {
            PressKeyboardKey('s');
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        Time.timeScale = 1;

        Assert.AreEqual(expected, movement.transform.position);
    }


    [UnityTest]
    public IEnumerator MoveRightSuccess()
    {
        var movement = CreateMovement();

        var input = new PlayerInput();
        input.Player.Enable();

        Time.timeScale = 20;

        var expected = movement.transform.position + Vector3.right * 20 * movement.Speed * Time.fixedDeltaTime;

        for (int i = 0; i < 20; i++)
        {
            PressKeyboardKey('d');
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        Time.timeScale = 1;

        Assert.AreEqual(expected, movement.transform.position);
    }


    [UnityTest]
    public IEnumerator MoveLeftSuccess()
    {
        var movement = CreateMovement();

        var input = new PlayerInput();
        input.Player.Enable();

        Time.timeScale = 20;

        var expected = movement.transform.position + Vector3.left * 20 * movement.Speed * Time.fixedDeltaTime;

        for (int i = 0; i < 20; i++)
        {
            PressKeyboardKey('a');
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }

        Time.timeScale = 1;

        Assert.AreEqual(expected, movement.transform.position);
    }

    private PlayerMovement CreateMovement()
    {
        var gameObject = new GameObject();
        return gameObject.AddComponent<PlayerMovement>();
    }

    private void PressKeyboardKey(char key)
    {
        var keyboard = InputSystem.AddDevice<Keyboard>();

        switch (key)
        {
            case 'w':
                Press(keyboard.wKey);
                break;

            case 's':
                Press(keyboard.sKey);
                break;

            case 'a':
                Press(keyboard.aKey);
                break;

            case 'd':
                Press(keyboard.dKey);
                break;

            case 'e':
                Press(keyboard.eKey);
                break;
            default:
                break;
        }
    }
}
