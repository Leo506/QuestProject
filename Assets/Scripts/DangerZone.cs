using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] GameObject target;

    public static event System.Action DeathEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
            DeathEvent?.Invoke();
    }
}
