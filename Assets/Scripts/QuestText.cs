using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestText : MonoBehaviour
{
    [SerializeField] Text questGiveText;
    [SerializeField] Text questPassText;

    // Start is called before the first frame update
    void Start()
    {
        QuestGiver.QuestIsGivenEvent += OnQuestGive;
        QuestGiver.QuestAcceptEvent += OnPassQuest;
    }

    private void OnDestroy()
    {
        QuestGiver.QuestIsGivenEvent -= OnQuestGive;
        QuestGiver.QuestAcceptEvent -= OnPassQuest;
    }

    private void OnPassQuest()
    {
        questPassText.enabled = true;
        Invoke("HideQuestPassText", 2);
    }

    private void OnQuestGive()
    {
        questGiveText.enabled = true;
        Invoke("HideQuestText", 2);
    }

    private void HideQuestPassText()
    {
        questPassText.enabled = false;
    }

    private void HideQuestText()
    {
        questGiveText.enabled = false;
    }
}
