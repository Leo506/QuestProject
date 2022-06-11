using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour, IUsable
{
    [SerializeField] int npcID;

    public static event Action<int> QuestGivingStart;
    public static event Action QuestIsGivenEvent;

    private void Start()
    {
        DialogSystem.DialogText.DialogEndEvent += OnDialogEnd;
    }

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

        
    }

    private void OnDialogEnd(bool action)
    {
        if (QuestManager.CurrentQuest.GiverID != npcID || !action)
            return;


        QuestIsGivenEvent?.Invoke();
        QuestManager.CurrentQuest.State = QuestState.IN_PROGRESS;
    }

    private bool CheckQuestTarget()
    {
        Conditions.Condition condition = QuestManager.CurrentQuest.Condition;

        var targetField = condition.GetType().GetField("targetID");

        return targetField != null && (int)targetField.GetValue(condition) == npcID;
    }
}
