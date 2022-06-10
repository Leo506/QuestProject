using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBuilder : MonoBehaviour
{
    // TODO создать префаб триггера
    [SerializeField] Trigger triggerPrefab;
    [SerializeField] Transform triggersRoot;

    // Start is called before the first frame update
    void Start()
    {
        Conditions.DestinationCondition.CreateTriggerEvent += OnTriggerCreate;
    }

    private void OnDestroy()
    {
        Conditions.DestinationCondition.CreateTriggerEvent -= OnTriggerCreate;
    }

    private void OnTriggerCreate(Conditions.Vector3 pos)
    {
        Vector3 worldPos = new Vector3(pos.x, pos.y, pos.z);
        Instantiate(triggerPrefab, triggersRoot).transform.position = worldPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
