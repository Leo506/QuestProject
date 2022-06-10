using System;
using System.Collections;
using System.Collections.Generic;

namespace Conditions
{
    [System.Serializable]
    public struct Vector3
    {
        public float x, y, z;

        public Vector3(float x = 0, float y = 0, float z =0)
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public static implicit operator Vector3(UnityEngine.Vector3 vector)
        {
            return new Vector3 { x = vector.x, y = vector.y, z = vector.z };
        }
    }



    [System.Serializable]
    public class DestinationCondition : Condition
    {
        public Vector3 triggerPosition;                           // Место спавна триггера, который сообщит, пришел туда игрок или нет

        public static event Action<Vector3> CreateTriggerEvent;   // Событие сообщающее, что надо создать триггер

        public override void OnStart()
        {
            Quest.OnStateChange += StartQuest;
            Trigger.OnTriggerEnterEvent += EndQuest;
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


        private void EndQuest()
        {
            base.Pass();
        }

        public override string GetConditionName() => "Прибытие к цели";

        public override double GetProgress()
        {
            return 0;
        }
    }
}