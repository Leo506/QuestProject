using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class StartDialogComponent : MonoBehaviour, IUsable
    {
        private string dialogID;

        public void SetDialogID(string id) => dialogID = id;
        public string GetDialogID() => dialogID;

        public void Use()
        {
            DialogSystem.DialogText.Instance.StartDialog(dialogID);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "Player")
                return;

            Player.PlayerLogic player = other.gameObject.GetComponent<Player.PlayerLogic>();
            player.SetUsableObj(this);
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag != "Player")
                return;

            Player.PlayerLogic player = other.gameObject.GetComponent<Player.PlayerLogic>();
            player.UnsetUsableObj();
        }
    }
}