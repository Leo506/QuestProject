using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



namespace QuestLanguage
{
    public class ChatQuest : Quest
    {
        public ChatQuest(string parametr) : base(parametr)
        {
            List<string> parList = parametr.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).ToList();

            var idIndex = parList.IndexOf("id");

            int id = int.Parse(parList[idIndex + 1]);

            NPCManagement.NPCManager.GetNPC(id).gameObject.AddComponent<Components.SenderComponent>();
        }
    }
}