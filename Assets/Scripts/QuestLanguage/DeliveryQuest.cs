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
            // TODO find npces with id fromID and toID and attach Sender and Target components
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