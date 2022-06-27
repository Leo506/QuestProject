using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Components;


namespace QuestLanguage
{
    public class GettoQuest : Quest
    {
        private Vector3 triggerPos;
        private int fromID;

        private StartDialogComponent dialogComponent;

        public GettoQuest(string parametrs) : base(parametrs)
        {
            List<string> parList = parametrs.GetWords();

            var posIndex = parList.FindIndex(s => s == "pos");

            triggerPos.x = float.Parse(parList[posIndex + 1].ToString());
            triggerPos.y = float.Parse(parList[posIndex + 2].ToString());
            triggerPos.z = float.Parse(parList[posIndex + 3].ToString());

            var fromIndex = parList.FindIndex(s => s == "from");
            fromID = int.Parse(parList[fromIndex + 1].ToString());

            Trigger.OnTriggerEnterEvent += Pass;

            dialogComponent = NPCManagement.NPCManager.GetNPC(fromID).gameObject.AddComponent<StartDialogComponent>();
            dialogComponent.SetDialogID(QuestSystem.QuestManager.currentQuestID.ToString());

            DialogSystem.DialogText.DialogActionEvent += GotQuest;
        }

        private void GotQuest(string id, string action)
        {

            if (action == "GotQuest")
            {
                Got();
                TriggerBuilder.Instance.CreateTrigger(triggerPos);
                GameObject.Destroy(dialogComponent.gameObject);
            }
        }

        public override void Destroy()
        {
            Trigger.OnTriggerEnterEvent -= Pass;
            DialogSystem.DialogText.DialogActionEvent -= GotQuest;
        }
    }
}