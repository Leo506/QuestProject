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
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            type = "QuestLanguage." + myTI.ToTitleCase(type) + "Quest";
            Debug.Log("Type: " + type);
            System.Type t = System.Type.GetType(type);

            var parList = lines[0].Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).ToList();
            parList.RemoveAt(0);

            string newLine = "";
            foreach (var item in parList)
                newLine += item;


            return Activator.CreateInstance(t, new object[] { newLine });
        }
    }
}