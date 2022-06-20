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
        }


        public object CreateQuest()
        {
            object toReturn = null;

            foreach (var line in lines)
            {
                List<string> words = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string type = words[0];

                TextInfo tmp = new CultureInfo("en-US", false).TextInfo;

                if (IsQuestCommand(words[0]))
                {
                    type = "QuestLanguage." + tmp.ToTitleCase(type) + "Quest";
                    Type t = Type.GetType(type);

                    toReturn = Activator.CreateInstance(t, new object[] { line.Remove(0, words[0].Length) });
                }
                else
                {
                    type = "QuestLanguage." + tmp.ToTitleCase(type);
                    Type t = Type.GetType(type);
                    Activator.CreateInstance(t, new object[] { line.Remove(0, words[0].Length) });
                }
            }

            return toReturn;
        }

        private bool IsQuestCommand(string command)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return Type.GetType("QuestLanguage." + textInfo.ToTitleCase(command) + "Quest") != null;
        }
    }
}