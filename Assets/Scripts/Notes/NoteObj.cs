using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Notes
{
    public class NoteObj : MonoBehaviour, IUsable
    {
        public int NoteIndex;

        public void Use()
        {
            NotesControl.AddNewNote(NoteIndex);
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Player")
                return;

            var player = other.gameObject.GetComponent<Player.PlayerLogic>();

            player.SetUsableObj(this);
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag != "Player")
                return;


            var player = other.gameObject.GetComponent<Player.PlayerLogic>();

            player.UnsetUsableObj();
        }
    }
}