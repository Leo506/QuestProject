using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Components
{
    public class SenderComponent : MonoBehaviour, IUsable
    {
        private void OnEnable()
        {
            DialogSystem.DialogText.DialogActionEvent += OnDialogEnd;
        }

        private void OnDialogEnd(int id)
        {
            Debug.Log("OnDialogEnd Sender");
            Destroy(this);
        }

        public void Use()
        {
            DialogSystem.DialogText.Instance.StartDialog(QuestSystem.QuestManager.currentQuestID);
        }

        private void OnDestroy()
        {
            DialogSystem.DialogText.DialogEndEvent -= OnDialogEnd;
        }
    }
}