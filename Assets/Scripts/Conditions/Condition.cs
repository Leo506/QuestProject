using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conditions
{
    [System.Serializable]
    public class Condition
    {
        public event System.Action OnPass;
        public virtual double GetProgress() => 0;
        public virtual string GetConditionName() => "";

        public virtual void OnStart() { }

        protected void Pass() => OnPass?.Invoke();

    }
}