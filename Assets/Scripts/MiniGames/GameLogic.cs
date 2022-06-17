using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.Osu
{
    public class GameLogic : MonoBehaviour, IMiniGame
    {
        [SerializeField] ClickCheck check;
        [SerializeField] Slider enemySlider, playerSlider;

        public event Action<bool> GameOverEvent;   // true - победа false - поражение

        public static GameLogic Instance { get; private set; }


        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            check.RoundEndEvent += OnRoundEnd;
        }

        private void OnRoundEnd(int param)
        {
            enemySlider.gameObject.SetActive(true);
            playerSlider.gameObject.SetActive(true);

            enemySlider.value -= param;
            playerSlider.value -= 5 - param;

            if (enemySlider.value <= 0)
            {
                GameOverEvent?.Invoke(true);
                return;
            }

            if (playerSlider.value <= 0)
            {
                GameOverEvent?.Invoke(false);
                return;
            }


            Invoke("HideSliders", 5);
        }

        private void HideSliders()
        {
            enemySlider.gameObject.SetActive(false);
            playerSlider.gameObject.SetActive(false);
        }
    }
}