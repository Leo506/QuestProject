using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Components;

public class EnemyController : MonoBehaviour
{

    MovementComponent[] enemiesMovement;
    Enemy[] enemies;

    private void Awake()
    {
        enemies = FindObjectsOfType<Enemy>();
        enemiesMovement = new MovementComponent[enemies.Length];

        for (int i = 0; i < enemies.Length; i++)
        {
            enemiesMovement[i] = enemies[i].GetComponent<MovementComponent>();
            enemiesMovement[i].Speed = Random.Range(1, 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            var enemy = enemies[i];
            if (Vector3.Distance(enemy.transform.position, enemy.startNode.transform.position) < 0.3f)
            {
                enemy.startNode = enemy.startNode.NextNode;
            }

            var dir = enemy.startNode.transform.position - enemy.transform.position;
            dir = new Vector3(dir.x, 0, dir.z);

            enemiesMovement[i].Move(dir);
        }
    }
}
