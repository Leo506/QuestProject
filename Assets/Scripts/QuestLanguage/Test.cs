using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestLanguage
{
    public class Test : MonoBehaviour
    {
        [SerializeField] TextAsset asset;

        private void Start()
        {
            string toParse = asset.text;
            TextParser parser = new TextParser();
            parser.Parse(toParse);

            Quest quest = parser.CreateQuest() as Quest;
            quest.Start();
        }

        // Start is called before the first frame update
        void Update()
        {
            /*if (asset == null)
                return;

            string toParse = asset.text;
            TextParser parser = new TextParser();
            parser.Parse(toParse);

            foreach (var item in parser.GetCommands())
                Debug.Log(item);

            parser.CreateQuest();*/
        }
    }
}