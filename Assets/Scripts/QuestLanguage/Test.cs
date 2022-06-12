using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestLanguage
{
    [ExecuteAlways]
    public class Test : MonoBehaviour
    {
        [SerializeField] TextAsset asset;

        // Start is called before the first frame update
        void Update()
        {
            if (asset == null)
                return;

            string toParse = asset.text;
            TextParser parser = new TextParser();
            parser.Parse(toParse);

            foreach (var item in parser.GetCommands())
                Debug.Log(item);

            parser.CreateQuest();
        }
    }
}