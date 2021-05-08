using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(EnemyPathConnector))]
public class ahhhhh : Editor {
    private Vector3[] positions;

    void OnSceneGUI() {
        // target is item being selected. In this case, it's the enemies with EnemyPathConnector attached.
        // each PathEnemy will have an array of points, I haven't decided if we're using GameObjects or Vector3's yet.
        // The enemy will go back and forth, patrolling these points.
        // if the enemy spots the player, the enemy will pursue until the player is out of sight,
        // at which point it will use pathfinding to go back to its original patrol

        EnemyPathConnector connectedObjects = target as EnemyPathConnector;

        // if there are no points, just return.
        if (connectedObjects.points == null) return;

        // otherwise, we can do our funky business. >:)
        if (connectedObjects.points.Length > 0) {
            positions = new Vector3[connectedObjects.points.Length];
        }

        // 
        for (var i = 0; i < connectedObjects.points.Length; i++) {
            if (connectedObjects.points[i]) {
                positions[i] = connectedObjects.points[i].transform.position;
            } else {
                positions[i] = Vector3.zero;
            }
        }

        Handles.DrawPolyLine(positions);
    }
}