using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace QuestLanguage
{
    public class Spawn
    {
        public Spawn(string parametrs)
        {
            List<string> parList = parametrs.GetWords();

            string typeName = parList[0];
            Type type = Type.GetType("QuestLanguage." + typeName + "Spawner");

            var posIndex = parList.FindIndex(s => s == "pos");
            Debug.Log("X: " + parList[posIndex + 1]);
            float x = float.Parse(parList[posIndex + 1]);
            float y = float.Parse(parList[posIndex + 2]);
            float z = float.Parse(parList[posIndex + 3]);
            Vector3 pos = new Vector3(x, y, z);

            string str = "";
            for (int i = posIndex + 4; i < parList.Count; i++)
                str += parList[i] + " ";

            ISpawner spawner = Activator.CreateInstance(type) as ISpawner;
            spawner.Spawn(str, pos);
        }
    }
}