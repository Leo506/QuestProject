using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace QuestLanguage
{
    public interface ISpawner
    {
        void Spawn(string parametrs, Vector3 pos);
    }
}