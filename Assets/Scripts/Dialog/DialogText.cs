using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogSystem
{
    public class DialogText : MonoBehaviour
    {
        public static event Action<string> DialogStartEvent;              // ??????? ?????? ???????
        public static event Action<string> DialogEndEvent;                // ??????? ????????? ???????
        public static event Action<string, string> DialogActionEvent;     // ???????, ????????????, ??? ?? ?????? ????? ?????? ????????? 

        public static DialogText Instance;  // ????????

        private string currentDialogId;        // id ???????? ???????

        [SerializeField] Text mainText;
        [SerializeField] Button[] answerButtons;
        [SerializeField] Canvas dialogCanvas;

        Phrase currentPhrase;  // ???????????? ??? ??????????? ?? ???????

        
        void Start()
        {
            if (Instance != this && Instance != null)
                Destroy(Instance.gameObject);

            Instance = this;

            DialogButton.ChooseAnswerEvent += OnAnswerSelected;

        }

        private void OnDestroy()
        {
            DialogButton.ChooseAnswerEvent -= OnAnswerSelected;
        }

        private void OnEnable()
        {
            if (Instance != null)
                return;

            Instance = this;
        }

        public void InvokeStartDialogEvent()
        {
            DialogStartEvent?.Invoke(currentDialogId);
        }

        public void InvokeEndDialogEvent()
        {
            DialogEndEvent?.Invoke(currentDialogId);
        }

        public void StartDialog(string id, string path = "/Dialogs/Dialog.xml")
        {
            currentDialogId = id;

            DialogStartEvent?.Invoke(currentDialogId);  // ????????, ??? ?????? ???????

            if (dialogCanvas == null)
                return;

            dialogCanvas.enabled = true;
            currentPhrase = XmlToDialog.ReadDialog(Application.streamingAssetsPath+path, id);
            mainText.text = currentPhrase.Text;

            SetButtons();
        }

        private void OnAnswerSelected(Answer item)
        {
            if (item.HasAction)
            {
                DialogActionEvent?.Invoke(currentDialogId, item.Action);
            }

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