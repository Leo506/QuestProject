using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputSystem;
using System.Linq;
using System;

namespace Player
{
    namespace Player
    {
        [RequireComponent(typeof(CharacterController))]
        public class PlayerMovement : MonoBehaviour
        {
            [SerializeField] float speed;

            private float currentSpeed;

            private IInputController input;

            private CharacterController characterController;


            // Start is called before the first frame update
            void Start()
            {
                input = InputFactory.Instance.GetInputController();
                characterController = GetComponent<CharacterController>();
                DialogSystem.DialogText.DialogStartEvent += StopMove;
                DialogSystem.DialogText.DialogEndEvent += StartMove;
                CutSceneTrigger.CutSceneStartEvent += StopMove;
                currentSpeed = speed;
            }

            private void OnDestroy()
            {
                DialogSystem.DialogText.DialogStartEvent -= StopMove;
                DialogSystem.DialogText.DialogEndEvent -= StartMove;
                CutSceneTrigger.CutSceneStartEvent -= StopMove;
            }

            private void StartMove(string id)
            {
                currentSpeed = speed;
            }

            private void StartMove()
            {
                currentSpeed = speed;
            }

            private void StopMove(string id)
            {
                currentSpeed = 0;
            }

            private void StopMove()
            {
                currentSpeed = 0;
            }

            // Update is called once per frame
            void Update()
            {

                Vector3 movement = input.GetInputDir();
                movement *= currentSpeed * Time.deltaTime;

                if (movement == Vector3.zero)
                    return;

                transform.rotation = Quaternion.LookRotation(movement, Vector3.up);

                if (!characterController.isGrounded)
                    movement = new Vector3(movement.x, -10, movement.z);

                characterController.Move(movement);
            }
        }
    }
}