using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MiniGames;

namespace QuestLanguage
{
    public class MinigameQuest : Quest
    {
        GameObject miniGameObj;
        public MinigameQuest(string parametrs) : base(parametrs)
        {
            List<string> parList = parametrs.Split(new char[] { ' ' }).ToList();

            var idIndex = parList.FindIndex(s => s == "id");
            
            int gameId = int.Parse(parList[idIndex + 1]);

            var miniGame = Resources.Load<GameObject>($"MiniGames/MiniGame{gameId}");

            miniGameObj = GameObject.Instantiate(miniGame);

            Got();

            miniGameObj.GetComponentInChildren<IMiniGame>().GameOverEvent += OnPass;
        }

        public void OnPass(bool win)
        {
            if (!win)
                return; // TODO возврат на последний checkpoint

            GameObject.Destroy(miniGameObj);
            Pass();
            Debug.Log("After destroy");
        }
    }
}