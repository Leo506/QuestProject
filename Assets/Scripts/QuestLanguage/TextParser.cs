using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using System.Linq;

namespace QuestLanguage
{
    public class TextParser
    {
        string[] lines;
        public void Parse(string content)
        {
            lines = content.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in lines)
            {
                Debug.Log(item);
            }
        }

        public string[] GetCommands()
        {
            string[] toReturn = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                toReturn[i] = lines[i].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries)[0];
            }

            return toReturn;
        }

        public object CreateQuest()
        {
            string type = lines[0].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries)[0];
            lines[0] = lines[0].Remove(0, type.Length + 1);
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            type = "QuestLanguage." + myTI.ToTitleCase(type) + "Quest";
            Debug.Log("Type: " + type);
            System.Type t = System.Type.GetType(type);

            ExecuteAdditional();

            return Activator.CreateInstance(t, new object[] { lines[0] });
        }

        private void ExecuteAdditional()
        {
            for (int i = 1; i < lines.Length; i++)
            {
                string type = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                var newLine = lines[i].Remove(0, type.Length + 1);

                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                type = "QuestLanguage." + myTI.ToTitleCase(type);

                var t = Type.GetType(type);
                Activator.CreateInstance(t, new object[] { newLine });
            }
        }
    }
}