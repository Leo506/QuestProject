using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NPCManagement
{
    public class NPC : MonoBehaviour
    {
        [Header("ID персонажа")]
        public int npcID;

        // Start is called before the first frame update
        void Start()
        {
            NPCManager.RegistrateNPC(this);
        }

        private void OnDestroy()
        {
            NPCManager.RemoveNPC(this);
        }
    }
}