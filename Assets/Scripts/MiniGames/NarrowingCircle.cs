using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiniGames.Osu
{
    public class NarrowingCircle : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Narrowing());
        }

        
        IEnumerator Narrowing()
        {
            int countOfIter = 500;
            float desc = (transform.localScale.x - 1) / countOfIter;
            for (int i = 0; i < countOfIter; i++)
            {
                var size = transform.localScale;
                size.x -= desc;
                size.y -= desc;

                transform.localScale = size;

                yield return new WaitForSeconds(0.001f);
            }
            Destroy(gameObject);
        }
    }
}