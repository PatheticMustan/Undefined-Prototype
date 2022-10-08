using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(EnemyPathConnector))]
public class EnemyPathManager : Editor {
    private Vector3[] positions;

    void OnSceneGUI() {
        EnemyPathConnector connectedObjects = target as EnemyPathConnector;

        // if there are no points, just return.
        if (connectedObjects.points == null) return;

        // otherwise, we can do our funky business. >:)
        if (connectedObjects.points.Length > 0) {
            positions = new Vector3[
                connectedObjects.points.Length +
                (connectedObjects.willLoop? 1 : 0)
            ];
        }

        // add positions of points
        for (var i = 0; i < connectedObjects.points.Length; i++) {
            if (connectedObjects.points[i]) {
                positions[i] = connectedObjects.points[i].transform.position;
            } else {
                // if the position is unassigned, just default to (0, 0, 0)
                positions[i] = Vector3.zero;
            }
        }

        // if it's looped, connect it all together
        if (connectedObjects.willLoop) {
            positions[positions.Length - 1] = positions[0];
        }

        Handles.DrawPolyLine(positions);
    }
}