using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Networking;


public class CutSceneTrigger : MonoBehaviour
{
    private PlayableDirector director;


    private void OnEnable()
    {
        director = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            director.Play();
    }
}
