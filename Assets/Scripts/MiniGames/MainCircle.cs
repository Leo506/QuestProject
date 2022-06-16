using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MiniGames.Osu
{
    public class MainCircle : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GetComponentInChildren<NarrowingCircle>().NarrowingEndEvent += () => Destroy(gameObject);
        }
    }
}