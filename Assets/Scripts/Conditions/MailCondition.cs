using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conditions
{
    public class MailCondition : Condition
    {
        public GameObject target;
        public GameObject subject;

        public override string GetConditionName() => "Почтовый квест";

        public override double GetProgress()
        {
            return 0;
        }
    }
}