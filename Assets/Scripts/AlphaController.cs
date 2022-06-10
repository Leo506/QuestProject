using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaController : MonoBehaviour
{
    [SerializeField] GameObject target;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(CheckObstacles());        
    }


    IEnumerator CheckObstacles()
    {
        List<MeshRenderer> lastRenderes = new List<MeshRenderer>();
        MeshRenderer currentRenderer = null;
        while (true)
        {
            var pos = mainCamera.WorldToScreenPoint(target.transform.position);
            Ray ray = mainCamera.ScreenPointToRay(pos);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject != target)
                {
                    MeshRenderer renderer = hit.collider.gameObject.GetComponent<MeshRenderer>();
                    if (renderer == null)
                    {
                        yield return new WaitForSeconds(0.5f);
                        continue;
                    }
                    var color = renderer.material.color;
                    color.a = 0.5f;
                    renderer.material.color = color;
                    lastRenderes.Add(renderer);
                    currentRenderer = renderer;
                }
                else
                    currentRenderer = null;

                if (lastRenderes.Count != 0)
                {
                    foreach (var renderer in lastRenderes)
                    {
                        if (renderer == currentRenderer)
                            continue;
                        var color = renderer.material.color;
                        color.a = 1;
                        renderer.material.color = color;
                    }
                    lastRenderes.RemoveAll(r => r != currentRenderer);
                }
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
