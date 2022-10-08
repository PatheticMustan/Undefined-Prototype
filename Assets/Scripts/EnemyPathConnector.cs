using UnityEngine;

public class EnemyPathConnector : MonoBehaviour {
    public int currentPathPoint;
    public bool isPathBackwards;
    public bool willLoop;

    [Space]

    public GameObject[] points;

    // relies on EnemyPathManager to do the cool things. Without it, this is just an empty husk.
    public void OnValidate() {
        // Debug.Log("ahhh! you are valid!");
        // Debug.Log(points.Length);
    }
}
