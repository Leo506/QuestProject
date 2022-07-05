using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Notes
{
    public class NotesReader : MonoBehaviour
    {
        [SerializeField] private Canvas readerCanvas;
        [SerializeField] private Text titleText;
        [SerializeField] private Text bodyText;

        [SerializeField] private Canvas notesCanvas;
        [SerializeField] private Transform scrollViewContent;
        [SerializeField] private NoteButton noteButtonPrefab;

        private System.Action<int> recreateNotesCanvasAction;

        public static NotesReader Instance { get; private set; }

        private void Awake()
        {
            if (Instance != this && Instance != null)
                Destroy(Instance.gameObject);

            Instance = this;

        }

        private void Start()
        {
            NotesControl.NoteCollectedEvent += ReadNote;

            recreateNotesCanvasAction = index => CreateNotesCanvas();

            NotesControl.NoteCollectedEvent += recreateNotesCanvasAction;

            CreateNotesCanvas();
        }

        private void OnDestroy()
        {
            NotesControl.NoteCollectedEvent -= ReadNote;
            NotesControl.NoteCollectedEvent -= recreateNotesCanvasAction;
        }

        public void ReadNote(int index)
        {
            Debug.Log("Reading note with index: " + index);
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


        private void CreateNotesCanvas()
        {
            for (int i = 0; i < scrollViewContent.childCount; i++)
                Destroy(scrollViewContent.GetChild(i).gameObject);

            for (int i = 0; i < NotesControl.TARGET_NOTES_COUNT; i++)
            {
                var btn = Instantiate(noteButtonPrefab, scrollViewContent);
                btn.GetComponentInChildren<Text>().text = "Note " + i.ToString();

                btn.noteIndex = i;

                btn.GetComponent<UnityEngine.UI.Button>().enabled = NotesControl.Contains(i);
            }
        }
    }
}