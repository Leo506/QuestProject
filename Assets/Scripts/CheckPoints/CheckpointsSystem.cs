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
        var player = GameObject.FindObjectOfType<Player.PlayerLogic>();
        if (player == null)
            return;

        var checkpoint = new Checkpoint()
        {
            playerX = player.transform.position.x,
            playerY = player.transform.position.y,
            playerZ= player.transform.position.z,
            sceneName = SceneManager.GetActiveScene().name
        };

        new FileManipulator().CreateBinnaryFile<Checkpoint>(checkpoint, "Checkpoint.point");
    }

    public static void LoadCheckpoint()
    {
        var manip = new FileManipulator();
        var point = manip.ReadBinnaryFile<Checkpoint>("Checkpoint.point");

        //SceneManager.LoadScene(point.sceneName);

        GameObject.FindObjectOfType<Player.PlayerLogic>().transform.position = new Vector3(point.playerX, point.playerY, point.playerZ);
    }

    public static void Init()
    {
        QuestLanguage.Quest.QuestGotEvent += quest => CreateCheckpoint();
    }
}
