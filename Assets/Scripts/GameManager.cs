using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Conditions;

public class GameManager : MonoBehaviour
{

    public static Quest CurrentQuest
    {
        get
        {
            var condition = new MailCondition();
            condition.targetID = 1;

            Quest quest = new Quest();
            quest.id = 1;
            quest.Condition = condition;

            return quest;
        }
    }

    public static int GetGiverID() => 0;
}
