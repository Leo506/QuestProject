using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CrowdSystem : MonoBehaviour
{
    NavMeshAgent[] agents;
    
    
    [SerializeField] GameObject[] goals;

    private void Start()
    {
        agents = FindObjectsOfType<NavMeshAgent>();
    }

    private void Update()
    {
        foreach (var agent in agents)
        {
            if (agent.remainingDistance < 1)
            {
                agent.SetDestination(goals[Random.Range(0, goals.Length)].transform.position);
                agent.speed = Random.Range(1.0f, 2.0f);
            }
        }
    }
}
