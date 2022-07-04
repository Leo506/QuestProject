using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Escape
{
    public enum SeekerState
    { 
        FINDING,
        FOLLOWING
    }

    public class Seeker : MonoBehaviour
    {
        [SerializeField] private float speedMultiply;
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }

        private SeekerState _state;
        public SeekerState State
        {
            get => _state;
            set
            {
                switch (value)
                {
                    case SeekerState.FINDING:
                        if (_state != value)
                            agent.speed /= speedMultiply;
                        break;

                    case SeekerState.FOLLOWING:
                        if (_state != value)
                            agent.speed *= speedMultiply;
                        break;

                    default:
                        break;
                }

                _state = value;
            }
        }


        private void Awake()
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        }
    }
}