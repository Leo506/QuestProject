using System.Collections;
using System.Collections.Generic;
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
    }
}