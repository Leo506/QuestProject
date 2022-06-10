using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class QuestManager
{
    private static int currentQuestId = 0;
    public static Quest CurrentQuest { get; private set; }

    static QuestManager()
    {
        LoadQuest();

        Quest.OnStateChange += OnQuestStateChange;
    }

    private static void OnQuestStateChange(int id, QuestState state)
    {
        if (state == QuestState.PASS)
        {
            currentQuestId++;
            LoadQuest();
        }

        if (state == QuestState.IN_PROGRESS)
            CurrentQuest.Start();
    }

    private static void LoadQuest()
    {
        if (!File.Exists(Application.streamingAssetsPath + $"/Quests/Quest{currentQuestId}"))
            return;

        using (FileStream fs = File.OpenRead(Application.streamingAssetsPath + $"/Quests/Quest{currentQuestId}"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            CurrentQuest = formatter.Deserialize(fs) as Quest;
        }
    }
}
