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
        [SerializeField] Image background;

        public event Action<bool> GameOverEvent;   // true - победа false - поражение

        public static GameLogic Instance { get; private set; }


        // Start is called before the first frame update
        void Awake()
        {
            Instance = this;
            check.RoundEndEvent += OnRoundEnd;
        }

        private void OnRoundEnd(int param)
        {
            enemySlider.gameObject.SetActive(true);
            playerSlider.gameObject.SetActive(true);

            var color = background.color;
            background.color = new Color(color.r, color.g, color.g, 0.1f);

            enemySlider.value -= param;
            playerSlider.value -= 5 - param;

            if (enemySlider.value <= 0)
            {
                GameOverEvent?.Invoke(true);
                Debug.Log("Game over");
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

            var color = background.color;
            background.color = new Color(color.r, color.g, color.g, 1f);
        }
    }
}