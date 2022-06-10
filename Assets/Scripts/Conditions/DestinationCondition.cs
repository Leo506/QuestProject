using System;
using System.Collections;
using System.Collections.Generic;

namespace Conditions
{
    [System.Serializable]
    public struct Vector3
    {
        public float x, y, z;

        public static implicit operator Vector3(UnityEngine.Vector3 vector)
        {
            return new Vector3 { x = vector.x, y = vector.y, z = vector.z };
        }
    }



    [System.Serializable]
    public class DestinationCondition : Condition
    {
        public Vector3 triggerPosition;

        public static event Action<Vector3> CreateTriggerEvent;

        public DestinationCondition()
        {
            Quest.OnStateChange += StartQuest;
        }

        ~DestinationCondition()
        {
            Quest.OnStateChange -= StartQuest;
        }

        private void StartQuest(int id, QuestState state)
        {
            if (state != QuestState.IN_PROGRESS)
                return;

            CreateTriggerEvent?.Invoke(triggerPosition);
        }

        public override string GetConditionName() => "Прибытие к цели";

        public override double GetProgress()
        {
            return 0;
        }
    }
}