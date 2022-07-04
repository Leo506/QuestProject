using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public struct Checkpoint
{
    public float playerX;
    public float playerY;
    public float playerZ;

    public string sceneName;
}

public class CheckpointsSystem
{
    public static void CreateCheckpoint()
    {
        
    }

    public static void LoadCheckpoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void Init()
    {
        QuestLanguage.Quest.QuestGotEvent += quest => CreateCheckpoint();
    }
}
