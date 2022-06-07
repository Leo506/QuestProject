using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace InputSystem
{
    public interface IInputController
    {
        public event Action UseKeyDown;
        Vector3 GetInputDir();
    }
}