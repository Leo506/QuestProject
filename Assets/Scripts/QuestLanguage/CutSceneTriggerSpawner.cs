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
            List<string> parList = parametrs.GetWords();

            var sceneIndex = parList.FindIndex(s => s == "scene");

            int sceneNumber = int.Parse(parList[sceneIndex + 1]);

            var file = new FileManipulator();
            var basePath = file.GetFile<PathControl>("AllPath").PathToCutScenes;
            CutSceneTrigger trigger = Resources.Load<CutSceneTrigger>($"{basePath}/CutScene{sceneNumber}");

            GameObject.Instantiate(trigger).transform.position = pos;
        }
    }
}