using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



namespace QuestLanguage
{
    public class ChatQuest : Quest
    {
        private bool autoStart;

        public override void Start()
        {
            if (autoStart)
                Got();
        }

        public ChatQuest(string parametr) : base(parametr)
        {
            List<string> parList = parametr.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).ToList();

            var idIndex = parList.IndexOf("id");

            int id = int.Parse(parList[idIndex + 1]);

            NPCManagement.NPCManager.GetNPC(id).gameObject.AddComponent<Components.SenderComponent>();

            var playIndex = parList.IndexOf("autoStart");

            autoStart = bool.Parse(parList[playIndex + 1]);

            if (autoStart)
                DialogSystem.DialogText.DialogEndEvent += Pass;
            else
                DialogSystem.DialogText.DialogEndEvent += StartChatQuest;
        }


        private void Pass(bool param)
        {
            Pass();
        }

        private void StartChatQuest(bool param)
        {
            DialogSystem.DialogText.DialogEndEvent -= StartChatQuest;
            Got();
            DialogSystem.DialogText.DialogEndEvent += Pass;
        }
    }
}