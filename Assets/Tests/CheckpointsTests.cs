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

        checkpoints.CreateCheckpoint(0, Vector3.zero);

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

    class TestFileManip : IFileManipulator
    {
        public bool FileCreated { get; set; }
        public bool FileLoaded { get; set; }


        public void CreateBinnaryFile<T>(T content, string name)
        {
            FileCreated = true;
        }

        public T LoadBinnaryFile<T>(string name)
        {
            FileLoaded = true;
            return default(T);
        }
    }

}
