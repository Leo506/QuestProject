using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Components
{
    public class SenderComponent : MonoBehaviour, IUsable
    {
        public void Use()
        {
            DialogSystem.DialogText.Instance.StartDialog(QuestSystem.QuestManager.currentQuestID);
        }
    }
}