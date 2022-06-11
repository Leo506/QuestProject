using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBuilder : MonoBehaviour
{
    // TODO создать префаб триггера
    [SerializeField] Trigger triggerPrefab;
    [SerializeField] Transform triggersRoot;

    [SerializeField] Canvas triggerCanvas;
    [SerializeField] GameObject triggerPointer;

    [SerializeField] Transform player;

    Camera mainCamera;

    GameObject currentPointer;
    Transform currentTrigger;

    // Start is called before the first frame update
    void Start()
    {
        Conditions.DestinationCondition.CreateTriggerEvent += OnTriggerCreate;
        Trigger.OnTriggerEnterEvent += DestroyPointer;
        mainCamera = Camera.main;
    }

    private void DestroyPointer()
    {
        Destroy(currentPointer.gameObject);
    }

    private void OnDestroy()
    {
        Conditions.DestinationCondition.CreateTriggerEvent -= OnTriggerCreate;
    }

    private void OnTriggerCreate(Conditions.Vector3 pos)
    {
        Vector3 worldPos = new Vector3(pos.x, pos.y, pos.z);
        currentTrigger = Instantiate(triggerPrefab, triggersRoot).transform;
        currentTrigger.position = worldPos;

        currentPointer = Instantiate(triggerPointer, triggerCanvas.transform);

        Debug.Log("pointer created");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPointer == null || currentTrigger == null)
            return;

        Vector3 playerToTrigger = currentTrigger.position - player.position;
        Ray ray = new Ray(player.position, playerToTrigger);


        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        float minDistance = Mathf.Infinity;

        foreach (var item in planes)
        {
            if (item.Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                    minDistance = distance;
            }
        }

        Vector3 worldPos = ray.GetPoint(minDistance);
        Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPos);

        currentPointer.transform.position = screenPos;
    }
}
