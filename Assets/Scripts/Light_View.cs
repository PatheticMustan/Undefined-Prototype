using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_View : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    //private float fov;
    private Vector3 orgin;
    //private float startingangle;

    private void Start()
    {

        Vector3 orgin = Vector3.zero;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }


    private void Update()
    {
       


        float fov = 10f;
        int RayCount = 50;
        float angle = 0f;
        float angleincrease = fov / RayCount;
        float viewdistance = 5f;
       

        Vector3[] vertices = new Vector3[RayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[RayCount * 3];

        vertices[0] = orgin;


        int VertexIndex = 1;
        int TrianglesIndex = 0;
        for (int i = 0; i <= RayCount; i++)
        {

            Vector3 vertex;
            RaycastHit2D raycasthit2D = Physics2D.Raycast(orgin, GetVectorFromAngle(angle), viewdistance,layerMask);
            if (raycasthit2D.collider == null)
            {
                vertex = orgin + GetVectorFromAngle(angle) * viewdistance;
            }
            else
            {
                vertex = raycasthit2D.point;
            }

            vertices[VertexIndex] = vertex;

            if (i > 0)
            {
                triangles[TrianglesIndex + 0] = 0;
                triangles[TrianglesIndex + 1] = VertexIndex - 1;
                triangles[TrianglesIndex + 2] = VertexIndex;

                TrianglesIndex += 3;
            }

            VertexIndex ++;
        angle -= angleincrease;
        }





        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;


    }

    public static Vector3 GetVectorFromAngle(float angle)
    {

        float anglerad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(anglerad), Mathf.Sin(anglerad));

    }

    public static float GetAngleFromVectorFloat(Vector3 dir) {

        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

   // private void SetOrgin(Vector3 orgin) {

       // this.orgin = orgin;    

    //}

    //private void SetAimDirection(Vector3 AimDirection) 
    //{

       // startingangle = GetAngleFromVectorFloat(AimDirection) - fov / 2f; 
    
   // }
}
