using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_View : MonoBehaviour {
    private LayerMask layerMask;
    private Mesh mesh;
    //private float fov;
    private Vector3 origin;
    //private float startingangle;

    public int fov = 360;
    public int rayCount = 180;
    public int angle = 0;
    public float rayDistance = 5f;

    public bool verbose = true;

    public string[] layers = new string[] { "Wall", "Crate" };

    void Start() {
        origin = Vector3.zero;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        layerMask = LayerMask.GetMask(layers);
    }


    void Update() {
        /*if (Input.GetKey(KeyCode.LeftBracket)) {
            angle += 2;
        }
        if (Input.GetKey(KeyCode.RightBracket)) {
            angle -= 2;
        }*/

        float rayAngle = angle;
        float angleIncrease = fov / rayCount;

        // 1 triangle will have 3 points
        // 2 triangles, sharing two points, will have 4 points
        // thus, n triangles will take n+2 points
        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;


        int VertexIndex = 1;
        int TrianglesIndex = 0;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            RaycastHit2D raycasthit2D = Physics2D.Raycast(origin, GetVectorFromAngle(rayAngle), rayDistance, layerMask);

            Debug.DrawRay(origin, GetVectorFromAngle(rayAngle), Color.green);

            if (raycasthit2D.collider != null) {
                Debug.Log(raycasthit2D.collider.gameObject.name);
                vertex = raycasthit2D.point;
            } else {
                vertex = origin + GetVectorFromAngle(rayAngle) * rayDistance;
            }

            vertices[VertexIndex] = vertex;

            if (i > 0) {
                triangles[TrianglesIndex + 0] = 0;
                triangles[TrianglesIndex + 1] = VertexIndex - 1;
                triangles[TrianglesIndex + 2] = VertexIndex;

                TrianglesIndex += 3;
            }

            VertexIndex++;
            rayAngle -= angleIncrease;
        }

        /*mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;*/
    }

    public static Vector3 GetVectorFromAngle(float angle) {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    // private void SetOrgin(Vector3 origin) {
    //     this.origin = origin;    
    // }

    // private void SetAimDirection(Vector3 AimDirection) {
    //     startingangle = GetAngleFromVectorFloat(AimDirection) - fov / 2f; 
    // }
}