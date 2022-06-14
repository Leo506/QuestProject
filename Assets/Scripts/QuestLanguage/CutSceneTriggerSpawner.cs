using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace QuestLanguage
{
    public class CutSceneTriggerSpawner : ISpawner
    {
        public void Spawn(string parametrs, Vector3 pos)
        {
            List<string> parList = parametrs.Split(new char[] { ' ' }, System.StringSplitOptions.RemoveEmptyEntries).ToList();

            var sceneIndex = parList.FindIndex(s => s == "scene");

            int sceneNumber = int.Parse(parList[sceneIndex + 1]);

            CutSceneTrigger trigger = Resources.Load<CutSceneTrigger>($"CutScene{sceneNumber}");

            GameObject.Instantiate(trigger).transform.position = pos;
        }
    }
}