using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour, IUsable
{
    [SerializeField] int npcID;

    public static event System.Action QuestIsGivenEvent;
    public static event System.Action QuestAcceptEvent;

    public void Use()
    {
        if (CheckQuestTarget())
            AcceptQuest();
        else
        {
            if (GameManager.GetGiverID() == npcID)
                QuestIsGivenEvent?.Invoke();
        }
    }

    public void AcceptQuest()
    {
        QuestAcceptEvent?.Invoke();
        Debug.Log(" вест сдан");
    }

    private bool CheckQuestTarget()
    {
        Quest currentQuest = GameManager.CurrentQuest;

        Conditions.Condition condition = currentQuest.Condition;

        var questTarget = condition.GetType().GetField("targetID");

        Debug.Log(questTarget);

        return questTarget != null && ((int)questTarget.GetValue(condition)) == npcID;
    }
}
