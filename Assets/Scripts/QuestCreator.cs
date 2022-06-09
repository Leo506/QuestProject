using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class QuestCreator : MonoBehaviour
{
    [Header("Создание квеста")]
    [SerializeField] string Title;
    [SerializeField] public string Description;
    [SerializeField] int id;
    [SerializeField] int GiverID;
    [SerializeField] QuestState State;
    [SerializeReference] public Conditions.Condition condition = new Conditions.MailCondition();

    public void CreateQuest()
    {
        Quest quest = new Quest();
        quest.id = id;
        quest.Description = Description;
        quest.Title = Title;
        quest.Condition = condition;

        using (FileStream fs = File.Create(Application.streamingAssetsPath + $"/Quests/Quest{id}"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, quest);
        }
    }

    private void Start()
    {
        using (FileStream fs = File.Open(Application.streamingAssetsPath + $"/Quests/Quest{id}", FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Quest quest = formatter.Deserialize(fs) as Quest;

            Debug.Log(quest.Title);
        }
    }
}
