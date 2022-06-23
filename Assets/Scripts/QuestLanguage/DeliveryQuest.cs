using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace QuestLanguage
{
    public class DeliveryQuest : Quest
    {
        int fromID;
        int toID;

        public DeliveryQuest(string parametrs) : base(parametrs)
        {
            Debug.Log(parametrs);

            List<string> parList = parametrs.GetWords();

            var tmp = parList.FindIndex(s => s == "from");
            fromID = int.Parse(parList[tmp + 1]);

            tmp = parList.FindIndex(s => s == "to");
            toID = int.Parse(parList[tmp + 1]);


            NPCManagement.NPCManager.GetNPC(fromID).gameObject.AddComponent<Components.SenderComponent>();
            var target = NPCManagement.NPCManager.GetNPC(toID).gameObject.AddComponent<Components.TargetComponent>();
            
            target.TargetGotMailEvent += Pass;                        // Условие сдачи квеста - получение посылки адресатом

            DialogSystem.DialogText.DialogActionEvent += GotQuest;    // Условие получения квеста
        }

        private void GotQuest(string id, string action)
        {
            if (action == "GotQuest")
                Got();
        }

        public override void Destroy()
        {
            DialogSystem.DialogText.DialogActionEvent -= GotQuest;
        }
    }
}