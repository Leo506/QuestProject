using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace QuestLanguage
{
    public class DeliveryQuest : Quest
    {
        int fromID;
        int toID;

        public override void Start()
        {
            NPCManagement.NPCManager.GetNPC(fromID).gameObject.AddComponent<Components.SenderComponent>();
            var target = NPCManagement.NPCManager.GetNPC(toID).gameObject.AddComponent<Components.TargetComponent>();
            target.TargetGotMailEvent += Pass;
        }

        public DeliveryQuest(string parametrs)
        {
            Debug.Log(parametrs);
            parametrs = parametrs.Remove(0, 4);

            fromID = GetFirstNumber(parametrs);

            parametrs = parametrs.Remove(0, fromID.ToString().Length + 2);


            toID = GetFirstNumber(parametrs);
            Debug.Log("Delivery quest is created from " + fromID + " to " + toID);
        }


        private int GetFirstNumber(string str)
        {
            string number = "";
            int i = 0;
            while (int.TryParse(str[i].ToString(), out int n) && i < str.Length)
            {
                number += str[i];
                i++;
            }

            return int.Parse(number);
        }
    }
}