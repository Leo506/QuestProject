using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestLanguage;
using System.Linq;
using System;

namespace BullyFight
{
    public class StartBullyFight : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            QuestSystem.QuestManager.LoadQuest(4);
            QuestSystem.QuestManager.QuestLoadedEvent += OnQuestLoaded;
        }

        private void OnQuestLoaded()
        {
            FindObjectsOfType<MonoBehaviour>().OfType<MiniGames.IMiniGame>().First().GameOverEvent += win => { if (win) DialogSystem.DialogText.Instance.StartDialog(QuestSystem.QuestManager.currentQuestID.ToString()); };
            QuestSystem.QuestManager.QuestLoadedEvent -= OnQuestLoaded;
        
        }
    }
}