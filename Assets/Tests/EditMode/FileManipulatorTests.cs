using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO;


public class FileManipulatorTests
{
    [Test]
    public void GetQuestTextSuccess()
    {
        FileManipulator file = new FileManipulator();

        var result = file.GetTextFileContent("Quests/Quest1");
        var expected = "delivery from 0 to 1 dialogs 1 -1 name Помощь маме description Мама попросила меня отнести старому <имя> немного еды, а то тот уже совсем плох\r\n" +
            "spawn CutSceneTrigger pos 12,57 1 16,22 scene 0";

        Assert.AreEqual(expected, result);
    }


    [Test]
    public void GetCutScenePrefabSuccess()
    {
        FileManipulator file = new FileManipulator();
        var result = file.GetGameObject("CutScenes/CutScene0");

        Assert.NotNull(result);
    }


    [Test]
    public void GetMinigamePrefabSuccess()
    {
        FileManipulator file = new FileManipulator();
        var result = file.GetGameObject("MiniGames/MiniGame0");

        Assert.NotNull(result);
    }


    [Test]
    public void GetDialogSuccess()
    {
        FileManipulator file = new FileManipulator();

        var result = file.GetTextFileContent("Dialogs/Dialog");

        Assert.NotNull(result);
    }


    [Test]
    public void CreateBinnaryFileSuccess()
    {
        var file = new FileManipulator();

        file.CreateBinnaryFile<TestStruct>(new TestStruct() { a = 1 }, "TestFile.data");

        Assert.IsTrue(File.Exists(Application.persistentDataPath + "/TestFile.data"));
    }


    [Test]
    public void ReadBinnaryFileSuccess()
    {
        var file = new FileManipulator();
        file.CreateBinnaryFile<TestStruct>(new TestStruct() { a = 1 }, "TestFile.data");


        var result = file.ReadBinnaryFile<TestStruct>("TestFile.data");
        var expected = new TestStruct() { a = 1 };

        Assert.AreEqual(expected, result);
    }


    [System.Serializable]
    struct TestStruct
    {
        public int a;
    }
}
