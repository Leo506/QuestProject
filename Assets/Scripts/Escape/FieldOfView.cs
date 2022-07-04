using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Escape
{
    public class FieldOfView : MonoBehaviour
    {
        [SerializeField] private float distance;
        [SerializeField] private int frequency;

        [SerializeField] private float angle;

        [SerializeField] private MeshFilter meshFilter;

        [SerializeField] Seeker seeker;

        private Mesh mesh;

        private void OnDrawGizmos()
        {
            var angleOffset = angle / frequency;
            var startAngle = -angle / 2;

            for (int i = 0; i < frequency; i++)
            {
                Gizmos.DrawLine(transform.position, transform.position + DirFromAngle(startAngle) * distance);
                startAngle += angleOffset;
            }

        }


        private void Start()
        {
            mesh = new Mesh();
            mesh.name = "FOV";
            meshFilter.mesh = mesh;
        }

        private void Update()
        {
            CreateMesh();
        }

        private void CreateMesh()
        {
            var points = CreateRaycasts();
            Vector3[] vertices = new Vector3[points.Length + 1];

            vertices[0] = Vector3.zero;
            for (int i = 0; i < points.Length; i++)
                vertices[i + 1] = transform.InverseTransformPoint(points[i]);

            int[] triangles = new int[(vertices.Length - 2) * 3];
            for (int i = 0; i < vertices.Length; i++)
            {
                if (i >= vertices.Length - 2)
                    continue;

                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }

            mesh.Clear();
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();
        }

        private Vector3[] CreateRaycasts()
        {
            Vector3[] points = new Vector3[frequency];

            var angleOffset = angle / frequency;
            var startAngle = -angle / 2;

            bool hasPlayer = false;
            for (int i = 0; i < frequency; i++)
            {
                var dir = DirFromAngle(startAngle);
                Ray ray = new Ray(transform.position, dir);
                if (Physics.Raycast(ray, out RaycastHit hit, distance))
                {
                    points[i] = hit.point;
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        seeker.State = SeekerState.FOLLOWING;
                        hasPlayer = true;
                    }
                }
                else
                    points[i] = transform.position + dir * distance;

                startAngle += angleOffset;
            }

            if (!hasPlayer)
                seeker.State = SeekerState.FINDING;

            return points;
        }


        private Vector3 DirFromAngle(float angle)
        {
            angle += transform.eulerAngles.y;
            return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
        }

    }
}