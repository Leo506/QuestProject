using System;
using UnityEngine;
using Components;

namespace Player
{
    public class PlayerLogic : MonoBehaviour
    {
        public static event Action PlayerDiedEvent;
        public static event Action OnSetUsableObj;
        public static event Action OnUnsetUsableObj;

        private IUsable currentUsableObj;
        private bool isInited = false;

        private MovementComponent movement;

        Action<string>[] actions;
        Action<int> stopAction;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            var playerInput = new PlayerInput();
            playerInput.Player.Enable();
            playerInput.Player.Using.performed += context => UseObj();

            movement = GetComponent<MovementComponent>();
            if (movement == null)
                movement = gameObject.AddComponent<MovementComponent>();

            actions = new Action<string>[]
            {
                id => movement?.StopMove(),
                id => movement?.StartMove()
            };

            stopAction = index => movement.StopMove();

            DialogSystem.DialogText.DialogStartEvent += actions[0];
            DialogSystem.DialogText.DialogEndEvent += actions[1];
            CutSceneTrigger.CutSceneStartEvent += movement.StopMove;
            Notes.NotesControl.NoteCollectedEvent += stopAction;

            isInited = true;
        }


        private void OnDestroy()
        {
            DialogSystem.DialogText.DialogStartEvent -= actions[0];
            DialogSystem.DialogText.DialogEndEvent -= actions[1];
            CutSceneTrigger.CutSceneStartEvent -= movement.StopMove;
            Notes.NotesControl.NoteCollectedEvent += stopAction;
        }


        public void SetUsableObj(IUsable obj)
        {
            currentUsableObj = obj;
            OnSetUsableObj?.Invoke();
        }

        public void UnsetUsableObj()
        {
            currentUsableObj = null;
            OnUnsetUsableObj?.Invoke();
        }


        public void UseObj()
        {
            if (currentUsableObj == null)
                return;
            currentUsableObj.Use();
            currentUsableObj = null;
            OnUnsetUsableObj?.Invoke();
        }

        public void Die()
        {
            PlayerDiedEvent?.Invoke();
        }
    }
}