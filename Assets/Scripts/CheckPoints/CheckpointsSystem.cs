using System.Collections;
using System.Collections.Generic;
using UnityEngine;


struct Checkpoint
{
    public int questId;

    public float playerX;
    public float playerY;
    public float playerZ;
}

public class CheckpointsSystem
{
    IFileManipulator fileManip;

    public CheckpointsSystem(IFileManipulator manip)
    {
        fileManip = manip;
    }

    public void CreateCheckpoint(int questID, Vector3 playerPos)
    {
        Checkpoint checkpoint = new Checkpoint()
        {
            questId = questID,
            playerX = playerPos.x,
            playerY = playerPos.y,
            playerZ = playerPos.z
        };

        fileManip.CreateBinnaryFile<Checkpoint>(checkpoint, "Checkpoint.point");
    }


    public void LoadCheckpoint()
    {
        var checkpoint = fileManip.LoadBinnaryFile<Checkpoint>("Checkpoint.point");
    }
}
