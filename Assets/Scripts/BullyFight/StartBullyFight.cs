using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestLanguage;
using System.Linq;


namespace BullyFight
{
    public class StartBullyFight : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            QuestSystem.QuestManager.LoadQuest(4);
            FindObjectsOfType<MonoBehaviour>().OfType<MiniGames.IMiniGame>().First().GameOverEvent += win => { if (win) DialogSystem.DialogText.Instance.StartDialog(QuestSystem.QuestManager.currentQuestID.ToString()); };
        }
    }
}