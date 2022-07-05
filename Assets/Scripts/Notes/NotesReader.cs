using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Notes
{
    public class NotesReader : MonoBehaviour
    {
        [SerializeField] private Canvas readerCanvas;
        [SerializeField] private Text titleText;
        [SerializeField] private Text bodyText;

        private void Start()
        {
            NotesControl.NoteCollectedEvent += ReadNote;
        }

        private void OnDestroy()
        {
            NotesControl.NoteCollectedEvent -= ReadNote;
        }

        public void ReadNote(int index)
        {
            readerCanvas.enabled = true;

            var file = new FileManipulator();
            Note note = file.GetFile<Note>($"Notes/Note{index}");

            titleText.text = note.Title;
            bodyText.text = note.Body;
        }


        public void EndRead()
        {
            readerCanvas.enabled = false;
        }
    }
}