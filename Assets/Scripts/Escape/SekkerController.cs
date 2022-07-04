using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Escape
{
    public class SekkerController : MonoBehaviour
    {
        [SerializeField] private Transform[] goals;
        [SerializeField] private Player.PlayerLogic player;
        private Seeker[] seekers;
        private NavMeshAgent[] seekersMovement;

        // Start is called before the first frame update
        void Start()
        {
            CheckpointsSystem.Init(); // TODO удалить
            seekers = FindObjectsOfType<Seeker>();
            seekersMovement = new NavMeshAgent[seekers.Length];
            for (int i = 0; i < seekers.Length; i++)
                seekersMovement[i] = seekers[i].agent;
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < seekers.Length; i++)
            {
                if (seekers[i].State == SeekerState.FOLLOWING)
                {
                    seekersMovement[i].SetDestination(player.transform.position);
                    if (seekersMovement[i].remainingDistance <= seekersMovement[i].stoppingDistance)
                        CheckpointsSystem.LoadCheckpoint();
                }
                else
                {
                    if (seekersMovement[i].remainingDistance <= seekersMovement[i].stoppingDistance)
                        seekersMovement[i].SetDestination(goals[Random.Range(0, goals.Length)].position);
                }
            }
        }
    }
}