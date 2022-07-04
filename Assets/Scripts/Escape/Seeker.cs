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
        [HideInInspector]
        public SeekerState state;
    }
}