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
        QuestLanguage.Quest.QuestGotEvent += OnQuestGiven;
        QuestLanguage.Quest.QuestPassedEvent += ClearAllTexts;
    }

    private void OnQuestGiven(QuestLanguage.Quest quest)
    {
        titleText.text = quest.QuestName;
        descriptionText.text = quest.QuestDescription;
    }

    private void ClearAllTexts(QuestLanguage.Quest quest)
    {
        Debug.Log("Quest text. Clear all text");
        if (titleText.text == quest.QuestName)
        {
            titleText.text = "";
            descriptionText.text = "";
        }
    }

    private void OnDestroy()
    {
        QuestLanguage.Quest.QuestGotEvent -= OnQuestGiven;
        QuestLanguage.Quest.QuestPassedEvent -= ClearAllTexts;
    }
}
