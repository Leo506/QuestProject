using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Components
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementComponent : MonoBehaviour
    {
        public float Speed;
        public bool UseGravity;

        private CharacterController controller;
        private bool canMove;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            canMove = true;
        }


        public void Move(Vector3 direction)
        {
            if (!canMove || direction == Vector3.zero)
                return;

            direction = direction.normalized;

            transform.rotation = Quaternion.LookRotation(direction);

            if (UseGravity)
            {
                if (!controller.isGrounded)
                    direction = new Vector3(direction.x, -9.8f, direction.z);
            }

            controller.Move(direction * Speed * Time.deltaTime);
        }


        public void StopMove()
        {
            canMove = false;
        }

        public void StartMove()
        {
            canMove = true;
        }
    }
}