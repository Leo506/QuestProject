using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour, IUsable
{
    [SerializeField] int npcID;
    public void Use()
    {
        if (QuestManager.CurrentQuest.State == QuestState.PASS)
            return;

        if (QuestManager.CurrentQuest.GiverID == npcID && QuestManager.CurrentQuest.State == QuestState.NONE)
        {
            Debug.Log("Quest is given");
            QuestManager.CurrentQuest.State = QuestState.IN_PROGRESS;
        }

        if (QuestManager.CurrentQuest.State == QuestState.IN_PROGRESS)
        {
            if (CheckQuestTarget())
            {
                Debug.Log("Quest is passed");
                QuestManager.CurrentQuest.State = QuestState.PASS;
            }
        }
    }

    private bool CheckQuestTarget()
    {
        Conditions.Condition condition = QuestManager.CurrentQuest.Condition;

        var targetField = condition.GetType().GetField("targetID");

        return targetField != null && (int)targetField.GetValue(condition) == npcID;
    }
}
