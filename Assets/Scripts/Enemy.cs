using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PathNode startNode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startNode == null)
            return;

        if (CheckDistance())
            startNode = startNode.NextNode;

        var dir = startNode.transform.position - this.transform.position;
        dir = dir.normalized;

        transform.Translate(dir * speed * Time.deltaTime);
    }

    private bool CheckDistance()
    {
        return Vector3.Distance(this.transform.position, startNode.transform.position) <= 0.1f;
    }
}
