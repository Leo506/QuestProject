using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Notes
{
    [CreateAssetMenu(menuName = "Data/Note", fileName = "Note")]
    public class Note : ScriptableObject
    {
        public string Title;

        [TextArea]
        public string Body;
    }
}