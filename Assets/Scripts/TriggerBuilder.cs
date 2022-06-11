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

    Dictionary<int, float> rotation = new Dictionary<int, float>
    {
        {0, -90 },
        {1, 90 },
        {2, 180 },
        {3, 0 }
    };

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

        // [0] = Left, [1] = Right, [2] = Down, [3] = Up, [4] = Near, [5] = Far
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);

        float minDistance = Mathf.Infinity;
        int index = 0;

        for (int i = 0; i < planes.Length; i++)
        {
            if (planes[i].Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    index = i;
                }
            }
        }

        minDistance = Mathf.Clamp(minDistance, 0, playerToTrigger.magnitude);

        Vector3 worldPos = ray.GetPoint(minDistance);
        Vector3 screenPos = mainCamera.WorldToScreenPoint(worldPos);

        currentPointer.transform.position = screenPos;
        currentPointer.transform.rotation = Quaternion.Euler(0, 0, rotation[index]);
    }
}
