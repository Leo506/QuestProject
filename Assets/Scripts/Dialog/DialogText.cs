using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DialogSystem
{
    public class DialogText : MonoBehaviour
    {
        public static event Action<bool> DialogEndEvent;

        public static DialogText Instance;

        [SerializeField] Text mainText;
        [SerializeField] Button[] answerButtons;
        [SerializeField] Canvas dialogCanvas;

        DialogItem currentItem;

        // Start is called before the first frame update
        void Start()
        {
            if (Instance != this && Instance != null)
                Destroy(Instance.gameObject);

            Instance = this;

            DialogButton.ChooseAnswerEvent += OnAnswerSelected;

            QuestGiver.QuestGivingStart += StartDialog;
        }

        public void StartDialog(int id)
        {
            dialogCanvas.enabled = true;
            currentItem = XmlToDialog.ReadDialog(Application.streamingAssetsPath + "/Dialogs/Dialog.xml", id)[0];
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
                DialogEndEvent?.Invoke(item.HasAction);
                
                dialogCanvas.enabled = false;
                return;
            }

            string debug = "item phrase: " + item.Phrase;
            for (int i = 0; i < item.Items.Count; i++)
            {
                debug += $" Items[{i}] phrase: {item.Items[i].Phrase}";
            }
            Debug.Log(debug);

            currentItem = item.Items[0];

            debug = "item phrase: " + currentItem.Phrase;
            for (int i = 0; i < currentItem.Items.Count; i++)
            {
                debug += $" Items[{i}] phrase: {currentItem.Items[i].Phrase}";
            }
            Debug.Log(debug);

            mainText.text = currentItem.Phrase;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                string newText = i >= currentItem.Items.Count ? "" : currentItem.Items[i].Phrase;

                answerButtons[i].GetComponent<Text>().text = newText;
                answerButtons[i].GetComponent<DialogButton>().item = i >= currentItem.Items.Count ? null : currentItem.Items[i];
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}