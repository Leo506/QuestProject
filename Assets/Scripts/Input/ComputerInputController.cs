using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace InputSystem
{
    public class ComputerInputController : MonoBehaviour, IInputController
    {
        public event System.Action UseKeyDown;

        private PlayerMovement playerMovement;

        private void Start()
        {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }

        public Vector3 GetInputDir()
        {
            var hor = Input.GetAxis("Horizontal");
            var vert = Input.GetAxis("Vertical");

            return new Vector3(hor, 0, vert);
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UseKeyDown?.Invoke();
            }

            var hor = Input.GetAxis("Horizontal");
            var vert = Input.GetAxis("Vertical");

            var movement = new Vector3(hor, 0, vert);
            if (movement != Vector3.zero)
            {
                playerMovement.Move(movement);
            }
        }
    }
}