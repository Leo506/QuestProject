using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class ComputerInputController : MonoBehaviour, IInputController
    {
        public event System.Action UseKeyDown;

        public Vector3 GetInputDir()
        {
            var hor = Input.GetAxis("Horizontal");
            var vert = Input.GetAxis("Vertical");

            return new Vector3(hor, 0, vert);
        }


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                UseKeyDown?.Invoke();
        }
    }
}