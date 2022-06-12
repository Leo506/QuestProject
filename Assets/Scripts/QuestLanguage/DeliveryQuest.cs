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

            string idString = "";
            int i = 0;
            while (int.TryParse(parametrs[i].ToString(), out int n) && i < parametrs.Length)
            {
                idString += parametrs[i];
                i++;
            }


            fromID = int.Parse(idString);

            parametrs = parametrs.Remove(0, idString.Length + 2);
            i = 0;
            idString = "";
            while (int.TryParse(parametrs[i].ToString(), out int n) && i < parametrs.Length)
            {
                idString += parametrs[i];
                i++;
            }

            toID = int.Parse(idString);
            Debug.Log("Delivery quest is created from " + fromID + " to " + toID);
        }
    }
}