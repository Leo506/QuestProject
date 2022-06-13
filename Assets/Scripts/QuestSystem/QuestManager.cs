using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using QuestLanguage;

namespace QuestSystem
{
    public class QuestManager
    {
        public static int currentQuestID { get; private set; }

        static QuestManager()
        {
            currentQuestID = 0;
            QuestLanguage.Quest.QuestPassedEvent += OnQuestPass;
            LoadQuest();
            Debug.Log("Quest is loaded");
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
            quest.Start();
        }
    }
}