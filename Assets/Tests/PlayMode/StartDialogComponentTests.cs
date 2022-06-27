using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Components;

public class StartDialogComponentTests
{
    [Test]
    public void StartDialogOnUseSuccess()
    {
        GameObject startDialogObj = new GameObject();
        var startDialog = startDialogObj.AddComponent<StartDialogComponent>();
        startDialog.SetDialogID("1");

        var dialog = new GameObject().AddComponent<DialogSystem.DialogText>();

        bool wasProcessed = false;
        DialogSystem.DialogText.DialogStartEvent += id => wasProcessed = true;

        startDialog.Use();

        Assert.IsTrue(wasProcessed);
    }
}
