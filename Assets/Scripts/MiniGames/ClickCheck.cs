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

        private NarrowingCircle circle;

        private void Start()
        {
            SpawnCircle();
        }

        private void SpawnCircle()
        {
            float minY = Camera.main.ScreenToWorldPoint(Vector2.zero).y;
            float maxY = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;

            float minX = Camera.main.ScreenToWorldPoint(Vector2.zero).x;
            float maxX = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;

            
            var randomY = Random.Range(-Screen.height / 2, Screen.height / 2);
            var randomX = Random.Range(-Screen.width / 2, Screen.width / 2);

            Vector2 randomScreenPos = new Vector2(randomX, randomY);
            Debug.Log("Spawn pos: " + randomScreenPos);

            var obj = Instantiate(circlePrefab, root);
            obj.transform.localPosition = randomScreenPos;

            circle = obj.GetComponentInChildren<NarrowingCircle>();
            circle.NarrowingEndEvent += SpawnCircle;

            obj.GetComponent<Button>().onClick.AddListener(OnClick);
            
        }

        public void OnClick()
        {
            if (circle == null)
                return;

            var size = circle.transform.localScale;

            if (size.x == 1 || size.x - 1 <= accuracy)
            {
                Debug.Log("OK!!!");
                Destroy(circle.transform.parent.gameObject);
                SpawnCircle();
            }
        }
    }
}