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
        [SerializeField] Text roundText;

        private int score = 0;

        private int currentNumber = 1;

        private NarrowingCircle circle;

        private void Start()
        {
            SpawnCircle();
            roundText.gameObject.SetActive(false);
        }

        private void SpawnCircle()
        {            
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

                currentNumber++;
                if (currentNumber > 5)
                {
                    currentNumber = 1;
                    RoundEnd();
                }
                else
                {
                    Destroy(circle.transform.parent.gameObject);
                    SpawnCircle();
                }
            }
        }

        private void RoundEnd()
        {
            Debug.Log("Round end");
            circle.NarrowingEndEvent -= SpawnCircle;
            
            roundText.gameObject.SetActive(true);

            Invoke("Start", 5);
        }
    }
}