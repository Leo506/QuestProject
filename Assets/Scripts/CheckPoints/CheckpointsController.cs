using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointsController : MonoBehaviour
{
    CheckpointsSystem checkpointsSystem;

    public static event System.Action<Checkpoint> CheckpointLoadedEvent;

    public static CheckpointsController Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != this)
            Destroy(this.gameObject);

        Instance = this;

        checkpointsSystem = new CheckpointsSystem(new FileManipulator());

        Player.PlayerLogic.PlayerDiedEvent += LoadCheckpoint;
        QuestLanguage.Quest.QuestGotEvent += CreateCheckpoint;

        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        Player.PlayerLogic.PlayerDiedEvent -= LoadCheckpoint;
        QuestLanguage.Quest.QuestGotEvent -= CreateCheckpoint;
    }

    private void CreateCheckpoint(QuestLanguage.Quest quest)
    {
        var playerTransform = FindObjectOfType<Player.PlayerLogic>().transform;
        if (playerTransform == null)
            return;
        checkpointsSystem.CreateCheckpoint(QuestSystem.QuestManager.currentQuestID, playerTransform.position, SceneManager.GetActiveScene().name);
    }


    public void LoadCheckpoint()
    {
        Debug.Log("Load checkpoint");
        checkpointsSystem.Load();

        SceneManager.LoadScene(CheckpointsSystem.checkpoint.sceneName);

        CheckpointLoadedEvent?.Invoke(CheckpointsSystem.checkpoint);
    }
}
