using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;


public class CheckpointTests
{
    [Test]
    public void CreateCheckpointSuccess()
    {
        var player = new GameObject().AddComponent<Player.PlayerLogic>();

        CheckpointsSystem.CreateCheckpoint();

        Assert.IsTrue(File.Exists(Application.persistentDataPath + "/Checkpoint.point"));
    }


    [Test]
    public void LoadCheckpointSuccess()
    {
        var player = new GameObject().AddComponent<Player.PlayerLogic>();

        CheckpointsSystem.CreateCheckpoint();

        player.transform.position = new Vector3(10, 0, 10);

        CheckpointsSystem.LoadCheckpoint();

        Assert.AreEqual(Vector3.zero, player.transform.position);
    }


    [Test]
    public void CreateCheckpointWhenGotQuestSuccess()
    {
        var player = new GameObject().AddComponent<Player.PlayerLogic>();
        var quest = new QuestLanguage.Quest("name Quest description Desc");
        CheckpointsSystem.Init();

        if (File.Exists(Application.persistentDataPath + "/Checkpoint.point"))
            File.Delete(Application.persistentDataPath + "/Checkpoint.point");

        quest.Got();

        Assert.IsTrue(File.Exists(Application.persistentDataPath + "/Checkpoint.point"));
    }
}
