using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed;

        private float currentSpeed;

        private CharacterController characterController;

        private bool isInited = false;

        private PlayerInput playerInput;

        // Start is called before the first frame update
        void Start()
        {
            InitComponent();
        }

        private void OnEnable()
        {
            if (isInited)
                return;

            InitComponent();
        }

        private void InitComponent()
        {
            characterController = GetComponent<CharacterController>();
            currentSpeed = Speed;

            playerInput = new PlayerInput();
            playerInput.Player.Enable();

            DialogSystem.DialogText.DialogStartEvent += OnDialogStart;
            DialogSystem.DialogText.DialogEndEvent += OnDialogEnd;

            isInited = true;
        }

        private void OnDialogEnd(string obj)
        {
            StartMove();
        }

        private void OnDialogStart(string obj)
        {
            StopMove();
        }

        private void OnDestroy()
        {
            CutSceneTrigger.CutSceneStartEvent -= StopMove;
        }

        public void StartMove()
        {
            currentSpeed = Speed;
        }

        public void StopMove()
        {
            currentSpeed = 0;
        }

        private void Update()
        {
            Vector2 inputVector = playerInput.Player.Movement.ReadValue<Vector2>();
            Move(new Vector3(inputVector.x, 0, inputVector.y));
        }

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            var ySpeed = 0;
            if (!characterController.isGrounded)
                ySpeed = -10;

            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            var movement = new Vector3(direction.x, ySpeed, direction.z) * currentSpeed * Time.deltaTime;
            

            characterController.Move(movement);
        }
    }
}