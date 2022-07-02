using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components;


public class InputController : MonoBehaviour
{
    [SerializeField] private MovementComponent movement;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var input = playerInput.Player.Movement.ReadValue<Vector2>();
        movement.Move(new Vector3(input.x, 0, input.y));
    }
}
