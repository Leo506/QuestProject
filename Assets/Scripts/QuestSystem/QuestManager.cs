using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using QuestLanguage;
using System;

namespace QuestSystem
{
    public class QuestManager
    {

        public static event Action<QuestLanguage.Quest> QuestIsGotEvent;
        public static int currentQuestID { get; private set; }

        private static QuestLanguage.Quest currentQuest;

        static QuestManager()
        {
            currentQuestID = 1;
            QuestLanguage.Quest.QuestPassedEvent += OnQuestPass;
            DialogSystem.DialogText.DialogEndEvent += QuestGot;
            LoadQuest();
            Debug.Log("Quest is loaded");
        }

        private static void QuestGot(bool action)
        {
            if (!action)
                return;

            currentQuest.Start();
            QuestIsGotEvent?.Invoke(currentQuest);
        }

        private static void OnQuestPass()
        {
            currentQuestID++;
            LoadQuest();
        }


        private static void LoadQuest()
        {
            if (!File.Exists(Application.streamingAssetsPath + $"/Quest{currentQuestID}.txt"))
                return;

            var text = File.ReadAllText(Application.streamingAssetsPath + $"/Quest{currentQuestID}.txt");

            var parser = new TextParser();
            parser.Parse(text);

            QuestLanguage.Quest quest = parser.CreateQuest() as QuestLanguage.Quest;

            currentQuest = quest;
        }
    }
}