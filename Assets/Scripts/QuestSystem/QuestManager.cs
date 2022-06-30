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

        private static QuestLanguage.Quest currentQuest;

        private static FileManipulator fileManipulator;

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

            if (currentQuest != null)
                currentQuest.Destroy();
            LoadQuest();
        }


        private static void LoadQuest()
        {
            string path = $"Quests/Quest{currentQuestID}";
            
            string questText = fileManipulator.GetTextFileContent(path);

            var parser = new TextParser();
            parser.Parse(questText);

            Quest quest = parser.CreateQuest() as Quest;

            currentQuest = quest;

            if (currentQuest != null)
                currentQuest.Start();
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