using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] public PathNode NextNode;

    private void OnDrawGizmos()
    {
        if (NextNode == null)
            return;

        Gizmos.DrawLine(this.transform.position, NextNode.transform.position);
    }
}
