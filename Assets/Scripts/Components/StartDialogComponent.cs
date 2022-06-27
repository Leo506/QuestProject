using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    public class StartDialogComponent : MonoBehaviour, IUsable
    {
        private string dialogID;

        public void SetDialogID(string id) => dialogID = id;

        public void Use()
        {
            DialogSystem.DialogText.Instance.StartDialog(dialogID);
        }
    }
}