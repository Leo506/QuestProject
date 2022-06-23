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
        public static int currentQuestID { get; private set; }
        public static event System.Action QuestLoadedEvent;

        private static QuestLanguage.Quest currentQuest;

        private static IFileManipulator fileManipulator;

        static QuestManager()
        {
            currentQuestID = 1;
            QuestLanguage.Quest.QuestPassedEvent += OnQuestPass;
            fileManipulator = new FileManipulator();
            LoadQuest();
            Debug.Log("Quest is loaded");
        }


        private static void OnQuestPass(Quest quest)
        {
            currentQuestID++;
            Debug.Log("Current quest id: " + currentQuestID);
            currentQuest.Destroy();
            LoadQuest();
        }


        private static void LoadQuest()
        {
            if (!File.Exists(Application.streamingAssetsPath + $"/Quest{currentQuestID}.txt"))
                return;

            fileManipulator.GetTextFileContent($"/Quest{currentQuestID}.txt", OnFileContentLoad);
            var text = File.ReadAllText(Application.streamingAssetsPath + $"/Quest{currentQuestID}.txt");

        }

        private static void OnFileContentLoad(string content)
        {
            var parser = new TextParser();
            parser.Parse(content);

            QuestLanguage.Quest quest = parser.CreateQuest() as QuestLanguage.Quest;

            currentQuest = quest;

            if (currentQuest != null)
            {
                currentQuest.Start();
                QuestLoadedEvent?.Invoke();
            }

        }

        public static void PassQuest()
        {
            if (currentQuest != null)
                currentQuest.Pass();
            else
            {
                currentQuestID++;
                LoadQuest();
            }
        }

        public static void LoadQuest(int id)
        {
            currentQuestID = id;

            LoadQuest();
        }
    }
}