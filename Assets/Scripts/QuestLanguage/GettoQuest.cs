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
            List<string> parList = parametrs.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).ToList();

            var posIndex = parList.FindIndex(s => s == "pos");

            triggerPos.x = float.Parse(parList[posIndex + 1].ToString());
            triggerPos.y = float.Parse(parList[posIndex + 2].ToString());
            triggerPos.z = float.Parse(parList[posIndex + 3].ToString());

            var fromIndex = parList.FindIndex(s => s == "from");
            fromID = int.Parse(parList[fromIndex + 1].ToString());

            Trigger.OnTriggerEnterEvent += Pass;

            NPCManagement.NPCManager.GetNPC(fromID).gameObject.AddComponent<Components.SenderComponent>();

            DialogSystem.DialogText.DialogEndEvent += param => { if (param) { TriggerBuilder.Instance.CreateTrigger(triggerPos); Got(); } };
        }

        ~GettoQuest()
        {
            Trigger.OnTriggerEnterEvent -= Pass;
        }
    }
}