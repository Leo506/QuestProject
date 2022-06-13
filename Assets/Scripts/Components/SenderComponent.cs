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
            DialogSystem.DialogText.DialogEndEvent += OnDialogEnd;
        }

        private void OnDialogEnd(bool action)
        {
            if (action)
                Destroy(this);
        }

        public void Use()
        {
            DialogSystem.DialogText.Instance.StartDialog(QuestSystem.QuestManager.currentQuestID);
        }

        private void OnDestroy()
        {
            DialogSystem.DialogText.DialogEndEvent += OnDialogEnd;
        }
    }
}