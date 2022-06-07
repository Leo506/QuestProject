using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class InputFactory
    {
        public static IInputController GetInputController()
        {
            return new ComputerInputController();
        }
    }
}