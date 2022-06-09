using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour, IUsable
{
    [SerializeField] int npcID;
    public void Use()
    {
        if (QuestManager.CurrentQuest.GiverID == npcID)
        {
            Debug.Log("Quest is given");
            QuestManager.CurrentQuest.State = QuestState.IN_PROGRESS;
        }
    }
}
