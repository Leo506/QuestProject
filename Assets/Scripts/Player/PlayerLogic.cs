using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerLogic : MonoBehaviour
    {
        IUsable currentUsableObj;

        public static event System.Action PlayerDiedEvent;

        private void Start()
        {
            var input = InputSystem.InputFactory.Instance.GetInputController();
            input.UseKeyDown += OnUse;
            CheckpointsController.CheckpointLoadedEvent += OnCheckpointLoaded;
        }

        private void OnCheckpointLoaded(Checkpoint obj)
        {
            var pos = new Vector3(obj.playerX, obj.playerY, obj.playerZ);
            GetComponent<Player.PlayerMovement>().enabled = false;
            this.transform.localPosition = pos;
            Invoke("EnableMovement", 2);
        }


        private void EnableMovement()
        {
            GetComponent<Player.PlayerMovement>().enabled = true;
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

        public void Die()
        {
            PlayerDiedEvent?.Invoke();
        }
    }
}