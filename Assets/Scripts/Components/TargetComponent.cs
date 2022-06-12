using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Components
{
    public class TargetComponent : MonoBehaviour, IUsable
    {
        public event System.Action TargetGotMailEvent;

        public void Use()
        {
            TargetGotMailEvent?.Invoke();
            Destroy(this);
        }
    }
}