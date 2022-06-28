using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Components;


namespace QuestLanguage
{
    public class ChatQuest : Quest
    {
        private int npcID;
        private StartDialogComponent dialogComponent;
        private string dialogID;

        public ChatQuest(string parametr) : base(parametr)
        {
            List<string> parList = parametr.GetWords();

            var idIndex = parList.IndexOf("id");

            npcID = int.Parse(parList[idIndex + 1]);

            var playIndex = parList.IndexOf("autoStart");

            bool autoStart = bool.Parse(parList[playIndex + 1]);

            var dialogIDIndex = parList.IndexOf("dialog");

            dialogID = parList[dialogIDIndex + 1];

            if (autoStart)
                Got();
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
        }

        public override void Destroy()
        {
            DialogSystem.DialogText.DialogActionEvent -= PassQuest;
        }

        public override void Got()
        {
            base.Got();
            dialogComponent = NPCManagement.NPCManager.GetNPC(npcID).gameObject.AddComponent<StartDialogComponent>();
            dialogComponent.SetDialogID(dialogID);

            DialogSystem.DialogText.DialogActionEvent -= GotQuest;

            DialogSystem.DialogText.DialogActionEvent += PassQuest;
        }

        public override void Pass()
        {
            GameObject.Destroy(dialogComponent);
            base.Pass();
        }
    }
}