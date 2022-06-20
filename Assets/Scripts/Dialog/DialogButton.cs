using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogSystem
{
    public class DialogButton : MonoBehaviour
    {
        public Answer answer;

        public static event System.Action<Answer> ChooseAnswerEvent;

        private void Start()
        {
            var btn = GetComponent<Button>();
            btn.onClick.AddListener(OnAnswerSelected);
        }

        private void OnAnswerSelected()
        {
            ChooseAnswerEvent?.Invoke(answer);
        }
    }
}