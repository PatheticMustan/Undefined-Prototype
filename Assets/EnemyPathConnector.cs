using UnityEngine;

public class EnemyPathConnector : MonoBehaviour {
    public GameObject[] points;

    public void OnValidate() {
        Debug.Log("ahhh! you are valid!");
        Debug.Log(points.Length);
    }
}
