using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Components;
using NPCManagement;
using QuestLanguage;


public class ChatQuestTests
{
    private const string questString = "id 0 autoStart false dialog 0 name none descrition";

    [Test]
    public void GiveDialogComponentToNPCSuccess()
    {
        var npc = new GameObject().AddComponent<NPC>();
        npc.npcID = 0;

        var chatQuest = new ChatQuest(questString);
        chatQuest.Got();

        Assert.NotNull(npc.GetComponent<StartDialogComponent>());

        GameObject.Destroy(npc.gameObject);
        NPCManager.Clear();
    }


    [UnityTest]
    public IEnumerator DestroyDialogComponentWhenQuestPass()
    {
        var npc = new GameObject().AddComponent<NPC>();
        npc.npcID = 0;

        var chatQuest = new ChatQuest(questString);
        chatQuest.Got();
        chatQuest.Pass();

        yield return new WaitForEndOfFrame();

        Assert.IsNull(npc.GetComponent<StartDialogComponent>());

        GameObject.Destroy(npc.gameObject);
        NPCManager.Clear();
    }


    [Test]
    public void SetDialogIDCorrect()
    {
        var npc = new GameObject().AddComponent<NPC>();
        npc.npcID = 0;

        var chatQuest = new ChatQuest(questString);
        chatQuest.Got();

        Assert.AreEqual("0", npc.GetComponent<StartDialogComponent>().GetDialogID());

        GameObject.Destroy(npc.gameObject);
        NPCManager.Clear();
    }


    [Test]
    public void AutostartWorkCorrect()
    {
        var npc = new GameObject().AddComponent<NPC>();
        npc.npcID = 0;

        var quest = "id 0 autoStart true dialog 0 name none description none";
        var chatQuest = new ChatQuest(quest);

        Assert.NotNull(npc.GetComponent<StartDialogComponent>());

        GameObject.Destroy(npc.gameObject);
        NPCManager.Clear();
    }
}
