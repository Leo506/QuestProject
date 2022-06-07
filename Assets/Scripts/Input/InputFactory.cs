using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputSystem
{
    public class InputFactory : MonoBehaviour
    {
        [SerializeField] ComputerInputController inputController;

        public static InputFactory Instance { get; private set; }

        private void Start()
        {
            if (Instance == null)
                Instance = this;
        }

        public IInputController GetInputController()
        {
            return inputController;
        }
    }
}