using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGames.Osu
{
    public class ClickCheck : MonoBehaviour
    {
        [SerializeField] Transform root;
        [SerializeField] GameObject circlePrefab;
        [SerializeField] float accuracy;
        [SerializeField] Text scoreText;

        public event System.Action<int> RoundEndEvent; // TODO не соотвествеут зоне отвественности скрипта. Перенести

        private int score = 0;

        private int currentNumber = 0;

        private NarrowingCircle circle;

        private bool gameOver = false;

        private void OnGameOver(bool obj)
        {
            gameOver = true;
        }

        private void Start()
        {
            GameLogic.Instance.GameOverEvent += OnGameOver;

            
            SpawnCircle();
        }


        // TODO не соотвествеут зоне отвественности скрипта. Перенести
        private void SpawnCircle()
        {            
            currentNumber++;
            if (currentNumber > 5)
            {
                currentNumber = 0;
                RoundEnd();
                return;
            }

            var randomY = Random.Range(-Screen.height / 2 + 371, Screen.height / 2 - 371);
            var randomX = Random.Range(-Screen.width / 2 + 251, Screen.width / 2 - 251);

            Vector2 randomScreenPos = new Vector2(randomX, randomY);
            Debug.Log("Spawn pos: " + randomScreenPos);

            var obj = Instantiate(circlePrefab, root);
            obj.transform.localPosition = randomScreenPos;
            obj.GetComponentInChildren<Text>().text = currentNumber.ToString();
            obj.GetComponent<Button>().onClick.AddListener(OnClick);

            circle = obj.GetComponentInChildren<NarrowingCircle>();
            circle.NarrowingEndEvent += SpawnCircle;

            
        }

        public void OnClick()
        {
            if (circle == null)
                return;

            var size = circle.transform.localScale;

            if (size.x == 1 || size.x - 1 <= accuracy)
            {
                score++;
                scoreText.text = "Score: " + score.ToString();

               
                Destroy(circle.transform.parent.gameObject);
                SpawnCircle();
            }
        }


        // TODO не соотвествеут зоне отвественности скрипта. Перенести
        private void RoundEnd()
        {
            RoundEndEvent?.Invoke(score);
            score = 0;
            scoreText.text = "Score: " + score.ToString();
            circle.NarrowingEndEvent -= SpawnCircle;

            if (!gameOver)
                Invoke("SpawnCircle", 5);
        }
    }
}