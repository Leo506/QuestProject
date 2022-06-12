using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace QuestLanguage
{
    public class Quest
    {
        public static event System.Action QuestPassedEvent;

        public void Pass() => QuestPassedEvent?.Invoke();
        public virtual void Start() { }
    }
}