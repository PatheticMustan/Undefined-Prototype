using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour {
    // set default values in inspector
    public float moveSpeed = 3;

    public float fovDegrees = 360;
    public float startDeg = 0;
    public float distance = 3;

    public bool detected;
    public string[] layers = new string[] { "Player", "Wall", "Box" };
    private int layerMask;

    private GameObject player;
    private Transform target;

    

    void Start() {
        detected = false;
        layerMask = LayerMask.GetMask(layers);

        player = GameObject.Find("Player_Prototype");
        target = player.GetComponent<Transform>();
    }

    void FixedUpdate() {
        // check if they're distance enough
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = target.position;
        if (Vector3.Distance(playerPos, enemyPos) > distance) return;

        // raycast!
        // shoot ray to detect walls or the player, whichever it hits first

        Vector3 enemyToPlayer = playerPos - enemyPos;

        startDeg %= 360;
        float endDeg = (startDeg + fovDegrees) % 360;
        float playerDeg = Quaternion.FromToRotation(Vector3.left, enemyPos - playerPos).eulerAngles.z;
        bool inFov = false;
        
        if (startDeg < endDeg) { // normal case
            inFov = startDeg <= playerDeg && playerDeg <= endDeg;
        } else { // end wraps around to 0
            inFov = startDeg <= playerDeg || playerDeg <= endDeg;
        }

        
        

        Debug.DrawRay(
            enemyPos,
            enemyToPlayer.normalized * distance,
            inFov ? Color.green : Color.red
        );

        Debug.DrawRay(enemyPos, Quaternion.AngleAxis(startDeg, Vector3.forward)*Vector3.right*distance, Color.yellow);
        Debug.DrawRay(enemyPos, Quaternion.AngleAxis(endDeg, Vector3.forward)*Vector3.right*distance, Color.yellow);

        if (!inFov) return;

        RaycastHit2D hit = Physics2D.Raycast(enemyPos, enemyToPlayer, distance, layerMask);

        if (hit.collider != null) {
            if (hit.collider.gameObject.tag == "Player") {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                detected = true;
            }
        } else {
            detected = false;
        }
    }
}
