using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Notes
{
    public class NoteButton : MonoBehaviour
    {
        [HideInInspector]
        public int noteIndex;


        public void OnClick()
        {
            NotesReader.Instance.ReadNote(noteIndex);
        }
    }
}