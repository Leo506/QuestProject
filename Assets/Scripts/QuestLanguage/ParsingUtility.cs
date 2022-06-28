using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuestLanguage
{
    public class ParsingUtility
    {
        List<string> parList;

        public ParsingUtility(string line)
        {
            parList = line.GetWords();
        }

        public T GetValue<T>(string valueName)
        {
            if (!parList.Contains(valueName))
                throw new System.InvalidOperationException($"Can't find value {valueName}");

            var index = parList.IndexOf(valueName);

            return (T)System.Convert.ChangeType(parList[index + 1], typeof(T));
        }
    }
}