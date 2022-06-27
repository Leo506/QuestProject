using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Components;


namespace QuestLanguage
{
    public class DeliveryQuest : Quest
    {
        private int fromID;
        private int toID;

        private StartDialogComponent sender;
        private StartDialogComponent target;

        public DeliveryQuest(string parametrs) : base(parametrs)
        {
            Debug.Log(parametrs);

            List<string> parList = parametrs.GetWords();

            var tmp = parList.FindIndex(s => s == "from");
            fromID = int.Parse(parList[tmp + 1]);

            tmp = parList.FindIndex(s => s == "to");
            toID = int.Parse(parList[tmp + 1]);


            sender = NPCManagement.NPCManager.GetNPC(fromID).gameObject.AddComponent<StartDialogComponent>();
            sender.SetDialogID(QuestSystem.QuestManager.currentQuestID.ToString());

            target = NPCManagement.NPCManager.GetNPC(toID).gameObject.AddComponent<StartDialogComponent>();
            target.SetDialogID((-QuestSystem.QuestManager.currentQuestID).ToString());

            DialogSystem.DialogText.DialogActionEvent += GotQuest;    // Условие получения квеста
        }

        private void GotQuest(string id, string action)
        {
            if (action == "GotQuest")
            {
                Got();
                GameObject.Destroy(sender);
                DialogSystem.DialogText.DialogActionEvent -= GotQuest;
                DialogSystem.DialogText.DialogActionEvent += PassQuest;
            }
        }

        private void PassQuest(string id, string action)
        {
            if (action != "PassQuest")
                return;

            GameObject.Destroy(target);

            Pass();
        }

        public override void Destroy()
        {
            DialogSystem.DialogText.DialogActionEvent -= GotQuest;
        }
    }
}