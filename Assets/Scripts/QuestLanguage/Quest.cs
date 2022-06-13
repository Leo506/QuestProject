using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace QuestLanguage
{
    public class Quest
    {
        public static event System.Action QuestPassedEvent;

        public string QuestName { get; protected set; }
        public string QuestDescription { get; protected set; }

        public void Pass() => QuestPassedEvent?.Invoke();
        public virtual void Start() { }

        public Quest(string parametrs)
        {
            List<string> parList = parametrs.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).ToList();

            var nameIndex = parList.FindIndex(s => s == "name");
            var descIndex = parList.FindIndex(s => s == "description");

            QuestName = "";
            for (int i = nameIndex + 1; i < descIndex; i++)
                QuestName += parList[i] + " ";

            QuestDescription = "";
            for (int i = descIndex + 1; i < parList.Count; i++)
                QuestDescription += parList[i] + " ";
        }
    }
}