using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogSystem
{
    public class DialogText : MonoBehaviour
    {
        public static event Action<string> DialogStartEvent;      // Событие начала диалога
        public static event Action<string> DialogEndEvent;        // Событие окончания диалога
        public static event Action<string> DialogActionEvent;     // Событие, обозначающее, что на данной фразе должно произойти действие

        public static DialogText Instance;  // Синглтон

        private string currentDialogId;        // id текущего диалога

        [SerializeField] Text mainText;
        [SerializeField] Button[] answerButtons;
        [SerializeField] Canvas dialogCanvas;

        Phrase currentPhrase;  // исопльзуется для продвижения по диалогу

        
        void Start()
        {
            if (Instance != this && Instance != null)
                Destroy(Instance.gameObject);

            Instance = this;

            DialogButton.ChooseAnswerEvent += OnAnswerSelected;

        }

        public void StartDialog(string id, string path = "/Dialogs/Dialog.xml")
        {
            currentDialogId = id;

            DialogStartEvent?.Invoke(currentDialogId);  // Сообщаем, что диалог начадся

            dialogCanvas.enabled = true;
            currentPhrase = XmlToDialog.ReadDialog(Application.streamingAssetsPath+path, id);
            mainText.text = currentPhrase.Text;

            SetButtons();
        }

        private void OnAnswerSelected(Answer item)
        {
            if (item.HasAction)
                DialogActionEvent?.Invoke(currentDialogId);

            if (item.Exit)
            {
                DialogEndEvent?.Invoke(currentDialogId);
                dialogCanvas.enabled = false;
                return;
            }
            

            currentPhrase = item.Next;
            mainText.text = currentPhrase.Text;

            SetButtons();
        }


        private void SetButtons()
        {
            for (int i = 0; i < answerButtons.Length; i++)
            {
                string text = i >= currentPhrase.answers.Count ? "" : currentPhrase.answers[i].Text;
                Answer answer = i >= currentPhrase.answers.Count ? null : currentPhrase.answers[i];

                answerButtons[i].GetComponent<Text>().text = text;
                answerButtons[i].GetComponent<DialogButton>().answer = answer;
            }
        }
    }
}