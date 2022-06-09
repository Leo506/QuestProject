using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestText : MonoBehaviour
{
    [SerializeField] Text titleText;
    [SerializeField] Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        Quest.OnStateChange += OnQuestGiven;
    }

    private void OnQuestGiven(int questID, QuestState state)
    {
        if (state == QuestState.IN_PROGRESS)
        {
            titleText.text = QuestManager.CurrentQuest.Title;
            descriptionText.text = QuestManager.CurrentQuest.Description;
        }
        else if (state == QuestState.PASS)
        {
            titleText.text = "";
            descriptionText.text = " вест сдан!!!";
            Invoke("ClearAllTexts", 2);
        }
        else
            ClearAllTexts();
    }

    private void ClearAllTexts()
    {
        titleText.text = "";
        descriptionText.text = "";
    }

    private void OnDestroy()
    {
        Quest.OnStateChange -= OnQuestGiven;
    }
}
