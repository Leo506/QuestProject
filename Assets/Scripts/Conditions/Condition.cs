using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conditions
{
    [System.Serializable]
    public abstract class Condition
    {
        public static event System.Action<int> OnPass;
        public abstract double GetProgress();
        public abstract string GetConditionName();


    }
}