using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.Osu
{
    public class GameLogic : MonoBehaviour
    {
        [SerializeField] ClickCheck check;
        [SerializeField] Slider enemySlider, playerSlider;


        // Start is called before the first frame update
        void Start()
        {
            check.RoundEndEvent += OnRoundEnd;
        }

        private void OnRoundEnd(int param)
        {
            enemySlider.gameObject.SetActive(true);
            playerSlider.gameObject.SetActive(true);

            enemySlider.value -= param;
            playerSlider.value -= 5 - param;

            Invoke("HideSliders", 5);
        }

        private void HideSliders()
        {
            enemySlider.gameObject.SetActive(false);
            playerSlider.gameObject.SetActive(false);
        }
    }
}