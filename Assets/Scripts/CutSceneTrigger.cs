using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Networking;


public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] bool hasDialog;
    [SerializeField] string dialogID;

    private PlayableDirector director;

    public static event System.Action CutSceneStartEvent;

    private void OnEnable()
    {
        director = GetComponent<PlayableDirector>();
        director.stopped += OnCutSceneStop;

        DialogSystem.DialogText.DialogEndEvent += DestroyTrigger;
    }

    private void DestroyTrigger(string id)
    {
        if (id == dialogID)
            Destroy(this.gameObject);
    }

    private void OnCutSceneStop(PlayableDirector obj)
    {
        if (hasDialog)
            DialogSystem.DialogText.Instance.StartDialog(dialogID, "/CutScenes/Dialog.xml");
    }

    private void OnDestroy()
    {
        director.stopped -= OnCutSceneStop;
        DialogSystem.DialogText.DialogEndEvent -= DestroyTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Player.PlayerMovement>().StopMove();
            CutSceneStartEvent?.Invoke();
            director.Play();
        }
    }
}
