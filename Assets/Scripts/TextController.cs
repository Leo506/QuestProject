using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    [SerializeField] Text questGiveText;
    [SerializeField] Text questPassText;
    [SerializeField] Text deathText;
    [SerializeField] Button replayButton;


    // Start is called before the first frame update
    void Start()
    {
        QuestGiver.QuestIsGivenEvent += OnQuestGive;
        QuestGiver.QuestAcceptEvent += OnPassQuest;
        DangerZone.DeathEvent += OnDeath;
    }

    private void OnDestroy()
    {
        QuestGiver.QuestIsGivenEvent -= OnQuestGive;
        QuestGiver.QuestAcceptEvent -= OnPassQuest;
        DangerZone.DeathEvent -= OnDeath;
    }

    private void OnDeath()
    {
        Time.timeScale = 0;
        deathText.enabled = true;
        replayButton.gameObject.SetActive(true);
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

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
