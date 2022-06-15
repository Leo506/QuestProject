using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogSystem
{
    public class DialogText : MonoBehaviour
    {
        public static event Action<string> DialogStartEvent;      // ������� ������ �������
        public static event Action<string> DialogEndEvent;        // ������� ��������� �������
        public static event Action<string> DialogActionEvent;     // �������, ������������, ��� �� ������ ����� ������ ��������� ��������

        public static DialogText Instance;  // ��������

        private string currentDialogId;        // id �������� �������

        [SerializeField] Text mainText;
        [SerializeField] Button[] answerButtons;
        [SerializeField] Canvas dialogCanvas;

        DialogItem currentItem;  // ������������ ��� ����������� �� �������

        
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

            DialogStartEvent?.Invoke(currentDialogId);  // ��������, ��� ������ �������

            dialogCanvas.enabled = true;
            currentItem = XmlToDialog.ReadDialog(Application.streamingAssetsPath + path, id)[0];
            mainText.text = currentItem.Phrase;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                string newText = i >= currentItem.Items.Count ? "" : currentItem.Items[i].Phrase;

                answerButtons[i].GetComponent<Text>().text = newText;
                answerButtons[i].GetComponent<DialogButton>().item = i >= currentItem.Items.Count ? null : currentItem.Items[i];
            }
        }

        private void OnAnswerSelected(DialogItem item)
        {
            if (item.Items.Count == 0)
            {
                DialogEndEvent?.Invoke(currentDialogId);
                DialogActionEvent?.Invoke(currentDialogId);

                dialogCanvas.enabled = false;
                return;
            }

            if (item.HasAction)
                DialogActionEvent?.Invoke(currentDialogId);

            
            currentItem = item.Items[0];

            
            mainText.text = currentItem.Phrase;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                string newText = i >= currentItem.Items.Count ? "" : currentItem.Items[i].Phrase;

                answerButtons[i].GetComponent<Text>().text = newText;
                answerButtons[i].GetComponent<DialogButton>().item = i >= currentItem.Items.Count ? null : currentItem.Items[i];
            }
        }
    }
}