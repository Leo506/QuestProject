using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NPCManagement
{
    public class NPC : MonoBehaviour
    {
        [Header("ID ���������")]
        public int npcID;

        // Start is called before the first frame update
        void Awake()
        {
            NPCManager.RegistrateNPC(this);
        }

        private void OnDestroy()
        {
            NPCManager.RemoveNPC(this);
        }
    }
}