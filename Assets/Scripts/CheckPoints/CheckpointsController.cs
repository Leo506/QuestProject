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
        // TODO подписка на событие смерти персонажа
        QuestLanguage.Quest.QuestGotEvent += CreateCheckpoint;
    }

    private void CreateCheckpoint(QuestLanguage.Quest quest)
    {
        checkpointsSystem.CreateCheckpoint(QuestSystem.QuestManager.currentQuestID, playerTransform.position);
    }


    private void LoadCheckpoint()
    {
        checkpointsSystem.LoadCheckpoint();
        CheckpointLoadedEvent?.Invoke(checkpointsSystem.checkpoint);
    }
}
