using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conditions
{
    [System.Serializable]
    public class MailCondition : Condition
    {
        [SerializeField] public GameObject target;
        [SerializeField] public int subject;

        public MailCondition()
        {
            target = null;
            subject = 0;
        }

        public override string GetConditionName() => "Почтовый квест";

        public override double GetProgress()
        {
            return 0;
        }
    }
}