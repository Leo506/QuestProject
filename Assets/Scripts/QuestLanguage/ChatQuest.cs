using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



namespace QuestLanguage
{
    public class ChatQuest : Quest
    {
        int npcID;
        public ChatQuest(string parametr) : base(parametr)
        {
            List<string> parList = parametr.GetWords();

            var idIndex = parList.IndexOf("id");

            npcID = int.Parse(parList[idIndex + 1]);

            var playIndex = parList.IndexOf("autoStart");

            bool autoStart = bool.Parse(parList[playIndex + 1]);

            if (autoStart)
                GotQuest("", "GotQuest");
            else
                DialogSystem.DialogText.DialogActionEvent += GotQuest;

            
        }

        private void PassQuest(string id, string action)
        {
            if (action == "PassQuest")
                Pass();
        }

        private void GotQuest(string id, string action)
        {
            if (action != "GotQuest")
                return;

            Got();
            NPCManagement.NPCManager.GetNPC(npcID).gameObject.AddComponent<Components.SenderComponent>();

            DialogSystem.DialogText.DialogActionEvent -= GotQuest;

            DialogSystem.DialogText.DialogActionEvent += PassQuest;
        }

        public override void Destroy()
        {
            DialogSystem.DialogText.DialogActionEvent -= PassQuest;
        }
    }
}