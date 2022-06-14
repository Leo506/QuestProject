using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Networking;


public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] bool hasDialog;

    private PlayableDirector director;

    public static event System.Action CutSceneStartEvent;

    private void OnEnable()
    {
        director = GetComponent<PlayableDirector>();
        director.stopped += OnCutSceneStop;
    }

    private void OnCutSceneStop(PlayableDirector obj)
    {
        if (hasDialog)
            DialogSystem.DialogText.Instance.StartDialog(0, "/CutScenes/Dialog.xml");
    }

    private void OnDestroy()
    {
        director.stopped -= OnCutSceneStop;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CutSceneStartEvent?.Invoke();
            director.Play();
        }
    }
}
