using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Components
{
    public class TargetComponent : MonoBehaviour, IUsable
    {
        public event System.Action TargetGotMailEvent;

        public void Use()
        {
            DialogSystem.DialogText.Instance.StartDialog(-QuestSystem.QuestManager.currentQuestID);

            TargetGotMailEvent?.Invoke();

            Destroy(this);
        }
    }
}