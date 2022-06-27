using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NPCManagement;


public class NpcManagerTests
{
    [Test]
    public void RegistrateNPCSuccess()
    {
        var npc = new GameObject().AddComponent<NPC>();
        npc.npcID = 0;

        Assert.NotNull(NPCManager.GetNPC(0));

        NPCManager.Clear();
    }


    [UnityTest]
    public IEnumerator RemoveNPCSuccess()
    {
        NPC npc = new GameObject().AddComponent<NPC>();
        npc.npcID = 0;

        Assert.NotNull(NPCManager.GetNPC(0));

        GameObject.Destroy(npc.gameObject);

        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        Assert.IsNull(NPCManager.GetNPC(0));

        NPCManager.Clear();
    }
}
