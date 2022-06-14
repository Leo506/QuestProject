using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


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
