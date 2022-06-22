using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;
using System.Linq;
using System;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        public float Speed;

        private float currentSpeed;

        private IInputController input;

        private CharacterController characterController;

        private bool isInited = false;


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

            if (DialogSystem.DialogText.Instance == null)
                return;
            DialogSystem.DialogText.Instance.DStartEvent += id => StopMove();
            DialogSystem.DialogText.Instance.DEndEvent += id => StartMove();

            isInited = true;
        }

        private void OnDestroy()
        {
            //DialogSystem.DialogText.DialogStartEvent -= StopMove;
            //DialogSystem.DialogText.DialogEndEvent -= StartMove;
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

        // Update is called once per frame
        /*void Update()
        {

            Vector3 movement = input.GetInputDir();
            movement *= currentSpeed * Time.deltaTime;

            if (movement == Vector3.zero)
                return;

            transform.rotation = Quaternion.LookRotation(movement, Vector3.up);

            if (!characterController.isGrounded)
                movement = new Vector3(movement.x, -10, movement.z);

            characterController.Move(movement);
        }*/

        public void Move(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;

            var ySpeed = 0;
            if (!characterController.isGrounded)
                ySpeed = -10;

            var movement = new Vector3(direction.x, ySpeed, direction.z) * currentSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(movement, Vector3.up);

            characterController.Move(movement);
        }
    }
}