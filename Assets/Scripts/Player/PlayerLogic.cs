using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerLogic : MonoBehaviour
    {
        IUsable currentUsableObj;

        private void Start()
        {
            var input = InputSystem.InputFactory.Instance.GetInputController();
            input.UseKeyDown += OnUse;
        }

        private void OnUse()
        {
            Debug.Log("Using... (from player logic)");
            currentUsableObj?.Use();
        }

        private void OnTriggerEnter(Collider collider)
        {
            IUsable obj = collider.gameObject.GetComponent<IUsable>();
            Debug.Log("Collision with usable obj? " + (obj != null));
            if (obj != null)
                currentUsableObj = obj;
        }

        private void OnTriggerExit(Collider collider)
        {
            currentUsableObj = null;
        }
    }
}