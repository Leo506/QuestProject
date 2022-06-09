using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class QuestManager
{
    private static int currentQuestId = 0;
    public static Quest CurrentQuest { get; private set; }

    static QuestManager()
    {
        using (FileStream fs = File.OpenRead(Application.streamingAssetsPath + $"/Quests/Quest{currentQuestId}"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            CurrentQuest = formatter.Deserialize(fs) as Quest;
        }
    }
}
