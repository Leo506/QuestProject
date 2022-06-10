using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour, IUsable
{
    [SerializeField] int npcID;

    public static event System.Action<int> QuestGivingStart;

    public void Use()
    {
        if (QuestManager.CurrentQuest.State == QuestState.PASS)
            return;

        if (QuestManager.CurrentQuest.GiverID == npcID && QuestManager.CurrentQuest.State == QuestState.NONE)
        {
            QuestGivingStart?.Invoke(QuestManager.CurrentQuest.id);
        }

        if (QuestManager.CurrentQuest.State == QuestState.IN_PROGRESS)
        {
            if (CheckQuestTarget())
            {
                Debug.Log("Quest is passed");
                QuestManager.CurrentQuest.State = QuestState.PASS;
            }
        }

        DialogSystem.DialogText.DialogEndEvent += OnDialogEnd;
    }

    private void OnDialogEnd()
    {
        if (QuestManager.CurrentQuest.GiverID != npcID)
            return;


        Debug.Log("Quest is given");
        QuestManager.CurrentQuest.State = QuestState.IN_PROGRESS;
    }

    private bool CheckQuestTarget()
    {
        Conditions.Condition condition = QuestManager.CurrentQuest.Condition;

        var targetField = condition.GetType().GetField("targetID");

        return targetField != null && (int)targetField.GetValue(condition) == npcID;
    }
}
