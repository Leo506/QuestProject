using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using QuestLanguage;
using Components;
using NPCManagement;

public class DeliveryQuestTests
{

    private const string questString = "from 0 to 1 dialogs 1 -1 name none description none";

    [Test]
    public void AddDialogComponentToQuestGiver()
    {
        PrepareScene(out NPC npc1, out NPC npc2);

        var deliveryQuest = new DeliveryQuest(questString);

        Assert.NotNull(npc1.GetComponent<StartDialogComponent>());

        ClearScene(npc1, npc2);
    }


    [Test]
    public void AddDialogComponentToQuestAccepter()
    {
        PrepareScene(out NPC npc1, out NPC npc2);

        
        var deliveryQuest = new DeliveryQuest(questString);

        Assert.NotNull(npc2.GetComponent<StartDialogComponent>());

        ClearScene(npc1, npc2);

    }


    [UnityTest]
    public IEnumerator DeleteDialogComponentFromQuestGiverWhenQuestGot()
    {
        PrepareScene(out NPC npc1, out NPC npc2);

        
        var deliveryQuest = new DeliveryQuest(questString);
        deliveryQuest.Got();

        yield return new WaitForEndOfFrame();

        Assert.IsNull(npc1.GetComponent<StartDialogComponent>());

        ClearScene(npc1, npc2);
    }


    [UnityTest]
    public IEnumerator DeleteDialogComponentFromQuestAcceptorWhenQuestPass()
    {
        PrepareScene(out NPC npc1, out NPC npc2);

        
        var deliveryQuest = new DeliveryQuest(questString);
        deliveryQuest.Pass();

        yield return new WaitForEndOfFrame();

        Assert.IsNull(npc2.GetComponent<StartDialogComponent>());

        ClearScene(npc1, npc2);
    }


    [Test]
    public void SetDialogIDSuccess()
    {
        PrepareScene(out NPC npc1, out NPC npc2);

        
        var deliveryQuest = new DeliveryQuest(questString);

        Assert.AreEqual("1", npc1.GetComponent<StartDialogComponent>().GetDialogID());
        Assert.AreEqual("-1", npc2.GetComponent<StartDialogComponent>().GetDialogID());

    }


    private void PrepareScene(out NPCManagement.NPC npc1, out NPCManagement.NPC npc2)
    {
        npc1 = new GameObject().AddComponent<NPCManagement.NPC>();
        npc1.npcID = 0;


        npc2 = new GameObject().AddComponent<NPCManagement.NPC>();
        npc2.npcID = 1;
    }

    private void ClearScene(NPCManagement.NPC npc1, NPCManagement.NPC npc2)
    {
        GameObject.Destroy(npc1);
        GameObject.Destroy(npc2);

        NPCManagement.NPCManager.Clear();
    }
}
