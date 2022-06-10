using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static event System.Action OnTriggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
            return;

        OnTriggerEnterEvent?.Invoke();
        Destroy(this.gameObject);
    }
}
