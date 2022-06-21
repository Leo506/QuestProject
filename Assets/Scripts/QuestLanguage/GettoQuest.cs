using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace QuestLanguage
{
    public class GettoQuest : Quest
    {
        Vector3 triggerPos;
        int fromID;

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

            NPCManagement.NPCManager.GetNPC(fromID).gameObject.AddComponent<Components.SenderComponent>();

            DialogSystem.DialogText.DialogActionEvent += GotQuest;
        }

        private void GotQuest(string id)
        {
            Debug.Log("Getto quest: " + id + " expected: " + QuestSystem.QuestManager.currentQuestID);
            if (id == QuestSystem.QuestManager.currentQuestID.ToString())
            {
                Got();
                TriggerBuilder.Instance.CreateTrigger(triggerPos);
            }
        }

        ~GettoQuest()
        {
            Trigger.OnTriggerEnterEvent -= Pass;
            DialogSystem.DialogText.DialogActionEvent -= GotQuest;
        }
    }
}