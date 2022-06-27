using System;
using UnityEngine;

namespace Player
{
    public class PlayerLogic : MonoBehaviour
    {
        public static event Action PlayerDiedEvent;

        IUsable currentUsableObj;
        bool isInited = false;

        private void Start()
        {
            Init();
        }


        private void OnEnable()
        {
            if (isInited)
                return;
            Init();
        }

        private void Init()
        {
            var playerInput = new PlayerInput();
            playerInput.Player.Enable();
            playerInput.Player.Using.performed += context => UseObj();

            isInited = true;
        }


        public void SetUsableObj(IUsable obj)
        {
            currentUsableObj = obj;
        }


        public void UseObj()
        {
            if (currentUsableObj == null)
                return;
            currentUsableObj.Use();
            currentUsableObj = null;
        }

        public void Die()
        {
            PlayerDiedEvent?.Invoke();
        }
    }
}