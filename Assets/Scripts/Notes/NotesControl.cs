using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Notes
{
    public static class NotesControl
    {
        public static event Action<int> NoteCollectedEvent; 

        private static List<int> collectedNotesIndexes;

        static NotesControl()
        {
            collectedNotesIndexes = new List<int>();
        }

        public static void AddNewNote(int index)
        {
            Debug.Log("Collected note: " + index);
            collectedNotesIndexes.Add(index);
            NoteCollectedEvent?.Invoke(index);
        }
    }
}