using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class ComputerInputController : IInputController
    {
        public Vector3 GetInputDir()
        {
            var hor = Input.GetAxis("Horizontal");
            var vert = Input.GetAxis("Vertical");

            return new Vector3(hor, 0, vert);
        }
    }
}