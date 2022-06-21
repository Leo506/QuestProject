using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CheckpointsTests
{
    [Test]
    public void TestCreateCheckpointsFileSuccess()
    {
        var fileManip = new TestFileManip();

        CheckpointsSystem checkpoints = new CheckpointsSystem(fileManip);

        checkpoints.CreateCheckpoint();

        Assert.IsTrue(fileManip.FileCreated);
    }


    [Test]
    public void TestLoadCheckpointsSuccess()
    {
        var fileManip = new TestFileManip();

        CheckpointsSystem checkpoints = new CheckpointsSystem(fileManip);

        checkpoints.LoadCheckpoint();

        Assert.IsTrue(fileManip.FileLoaded);
    }
}
