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
        internal static readonly int TARGET_NOTES_COUNT = 2;

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

        public static bool Contains(int index)
        {
            return collectedNotesIndexes.Contains(index);
        }
    }
}