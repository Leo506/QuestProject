using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace QuestLanguage
{
    public class Jump
    {
        public Jump(string parametr)
        {
            List<string> parList = parametr.GetWords();

            var index = parList.FindIndex(s => s == "to");

            parList[index + 2] = parList[index + 2].Trim();
            Debug.Log("TestScene length " + "TestScene".Length);
            Debug.Log("parList[index + 2].Length == \"TestScene\".Length " + (parList[index + 2].Length == "TestScene".Length));
            SceneManager.LoadScene(parList[index + 2]);
        }
    }
}