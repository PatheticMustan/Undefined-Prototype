using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_View : MonoBehaviour {
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    //private float fov;
    private Vector3 orgin;
    //private float startingangle;

    public float fov;
    public int RayCount;
    public float angle;
    public float angleincrease;
    public float viewdistance;

    public bool verbose = true;

    void Start() {
        Vector3 orgin = Vector3.zero;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        fov = 10f;
        RayCount = 50;
        angle = 0f;
        angleincrease = fov / RayCount;
        viewdistance = 5f;
    }


    void Update() {
        if (Input.GetKey(KeyCode.LeftBracket)) {
            angle += 0.1f;
        }
        if (Input.GetKey(KeyCode.RightBracket)) {
            angle -= 0.1f;
        }

        float rayAngle = angle;

        Vector3[] vertices = new Vector3[RayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[RayCount * 3];

        vertices[0] = orgin;


        int VertexIndex = 1;
        int TrianglesIndex = 0;
        for (int i = 0; i <= RayCount; i++) {
            Vector3 vertex;
            RaycastHit2D raycasthit2D = Physics2D.Raycast(orgin, GetVectorFromAngle(rayAngle), viewdistance, layerMask);
            if (raycasthit2D.collider == null) {
                vertex = orgin + GetVectorFromAngle(rayAngle) * viewdistance;
            } else {
                vertex = raycasthit2D.point;
            }

            vertices[VertexIndex] = vertex;

            if (i > 0) {
                triangles[TrianglesIndex + 0] = 0;
                triangles[TrianglesIndex + 1] = VertexIndex - 1;
                triangles[TrianglesIndex + 2] = VertexIndex;

                TrianglesIndex += 3;
            }

            VertexIndex++;
            // not sure what this is supposed to do
            rayAngle -= angleincrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public static Vector3 GetVectorFromAngle(float angle) {
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
    //     this.orgin = orgin;    
    // }

    // private void SetAimDirection(Vector3 AimDirection) {
    //     startingangle = GetAngleFromVectorFloat(AimDirection) - fov / 2f; 
    // }
}