using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiniGames.Osu
{
    public class NarrowingCircle : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float accuracy;

        public event System.Action NarrowingEndEvent;

        // Start is called before the first frame update
        void Start()
        {
            //StartCoroutine(Narrowing());
        }

        private void Update()
        {
            var size = transform.localScale;
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(1, 1, 1), speed * Time.deltaTime);

            

            if (transform.localScale.x - 1 <= accuracy)
            {
                NarrowingEndEvent?.Invoke();
                Destroy(this);
            }
        }
    }
}