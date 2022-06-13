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
        QuestSystem.QuestManager.QuestIsGotEvent += OnQuestGiven;
    }

    private void OnQuestGiven(QuestLanguage.Quest quest)
    {
        titleText.text = quest.QuestName;
        descriptionText.text = quest.QuestDescription;
    }

    private void ClearAllTexts()
    {
        titleText.text = "";
        descriptionText.text = "";
    }

    private void OnDestroy()
    {
        QuestSystem.QuestManager.QuestIsGotEvent -= OnQuestGiven;
    }
}
