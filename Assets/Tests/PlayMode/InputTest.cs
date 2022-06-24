using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

public class InputTest : InputTestFixture
{
    
    [Test]
    public void TestInputUp()
    {
        var playerInput = CreatePlayerInput();

        PressKeyboardKey('w');

        var expected = Vector2.up;

        Assert.AreEqual(expected, playerInput.Player.Movement.ReadValue<Vector2>());
    }

    [Test]
    public void TestInputDown()
    {
        var playerInput = CreatePlayerInput();

        PressKeyboardKey('s');

        var expected = Vector2.down;

        Assert.AreEqual(expected, playerInput.Player.Movement.ReadValue<Vector2>());
    }

    [Test]
    public void TestInputRight()
    {
        var playerInput = CreatePlayerInput();

        PressKeyboardKey('d');

        var expected = Vector2.right;

        Assert.AreEqual(expected, playerInput.Player.Movement.ReadValue<Vector2>());
    }


    [Test]
    public void TestInputLeft()
    {
        var playerInput = CreatePlayerInput();

        PressKeyboardKey('a');

        var expected = Vector2.left;

        Assert.AreEqual(expected, playerInput.Player.Movement.ReadValue<Vector2>());
    }

    [Test]
    public void TestInputUsing()
    {
        var playerInput = CreatePlayerInput();
        playerInput.Player.Using.performed += AssertPerformed;

        PressKeyboardKey('e');

    }

    private void AssertPerformed(InputAction.CallbackContext context)
    {
        Assert.AreEqual(InputActionPhase.Performed, context.phase);
    }

    private PlayerInput CreatePlayerInput()
    {
        var playerInput = new PlayerInput();
        playerInput.Player.Enable();

        return playerInput;
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
