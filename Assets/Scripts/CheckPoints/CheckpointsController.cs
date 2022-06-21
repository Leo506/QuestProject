using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsController : MonoBehaviour
{
    CheckpointsSystem checkpointsSystem;

    Transform playerTransform;

    public static event System.Action<Checkpoint> CheckpointLoadedEvent;

    // Start is called before the first frame update
    void Start()
    {
        checkpointsSystem = new CheckpointsSystem(new FileManipulator());

        playerTransform = FindObjectOfType<Player.PlayerLogic>().transform;

        Player.PlayerLogic.PlayerDiedEvent += LoadCheckpoint;
        QuestLanguage.Quest.QuestGotEvent += CreateCheckpoint;
    }

    private void CreateCheckpoint(QuestLanguage.Quest quest)
    {
        checkpointsSystem.CreateCheckpoint(QuestSystem.QuestManager.currentQuestID, playerTransform.position);
    }


    private void LoadCheckpoint()
    {
        Debug.Log("Load checkpoint");
        checkpointsSystem.LoadCheckpoint();
        CheckpointLoadedEvent?.Invoke(checkpointsSystem.checkpoint);
        /*var tmp = checkpointsSystem.checkpoint;
        Vector3 pos = new Vector3(tmp.playerX, tmp.playerY, tmp.playerZ);
        Debug.Log("Checkpoints pos: " + pos);
        FindObjectOfType<Player.PlayerLogic>().transform.SetPositionAndRotation(pos, Quaternion.identity);
        */
    }
}
