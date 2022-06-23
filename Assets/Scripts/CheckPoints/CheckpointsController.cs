using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (playerTransform == null)
            return;
        checkpointsSystem.CreateCheckpoint(QuestSystem.QuestManager.currentQuestID, playerTransform.position, SceneManager.GetActiveScene().name);
    }


    private void LoadCheckpoint()
    {
        Debug.Log("Load checkpoint");
        checkpointsSystem.LoadCheckpoint();

        if (SceneManager.GetActiveScene().name != checkpointsSystem.checkpoint.sceneName)
            SceneManager.LoadScene(checkpointsSystem.checkpoint.sceneName);

        CheckpointLoadedEvent?.Invoke(checkpointsSystem.checkpoint);
    }
}
