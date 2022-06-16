using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiniGames.Osu
{
    public class ClickCheck : MonoBehaviour
    {
        [SerializeField] NarrowingCircle circle;
        [SerializeField] float accuracy;


        public void OnClick()
        {
            if (circle == null)
                return;

            var size = circle.transform.localScale;

            if (size.x == 1 || size.x - 1 <= accuracy)
            {
                Debug.Log("OK!!!");
                Destroy(circle.transform.parent.gameObject);
            }
        }
    }
}