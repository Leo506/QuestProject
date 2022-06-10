using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Conditions
{
    [System.Serializable]
    public class MailCondition : Condition
    {
        [SerializeField] public int targetID;
        [SerializeField] public int subjectID;

        public MailCondition()
        {
            targetID = -1;
            subjectID = -1;
        }

        public override string GetConditionName() => "Почтовый квест";

        public override double GetProgress()
        {
            return 0;
        }

        public override void OnStart()
        {
            
        }
    }
}