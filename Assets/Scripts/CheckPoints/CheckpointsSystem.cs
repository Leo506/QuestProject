using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    IFileManipulator fileManip;

    public static Checkpoint checkpoint { get; private set; }

    public CheckpointsSystem(IFileManipulator manip)
    {
        fileManip = manip;
    }

    public void CreateCheckpoint(int questID, Vector3 playerPos, string sceneName)
    {
        checkpoint = new Checkpoint()
        {
            playerX = playerPos.x,
            playerY = playerPos.y,
            playerZ = playerPos.z,
            sceneName = sceneName
        };

        fileManip.CreateBinnaryFile<Checkpoint>(checkpoint, "Checkpoint.point");
    }


    public void Load()
    {
        checkpoint = fileManip.LoadBinnaryFile<Checkpoint>("Checkpoint.point");
    }

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
        };

        new FileManipulator().CreateBinnaryFile<Checkpoint>(checkpoint, "Checkpoint.point");
    }

    public static void LoadCheckpoint()
    {
        var manip = new FileManipulator();
        var point = manip.LoadBinnaryFile<Checkpoint>("Checkpoint.point");

       GameObject.FindObjectOfType<Player.PlayerLogic>().transform.position = new Vector3(point.playerX, point.playerY, point.playerZ);
    }

    public static void Init()
    {
        QuestLanguage.Quest.QuestGotEvent += quest => CreateCheckpoint();
    }
}
