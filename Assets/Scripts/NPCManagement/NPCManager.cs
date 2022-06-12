using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace NPCManagement
{
    public class NPCManager
    {
        static List<NPC> npcList = new List<NPC>();

        public static void RegistrateNPC(NPC npc)
        {
            npcList.Add(npc);
        }

        public static void RemoveNPC(NPC npc)
        {
            npcList.Remove(npc);
        }

        public static NPC GetNPC(int id)
        {
            return npcList.Where(n => n.npcID == id).First();
        }
    }
}