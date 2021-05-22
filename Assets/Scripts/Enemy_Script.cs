using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour {
    // set default values in inspector
    public float moveSpeed = 3;

    public float fovDegrees = 360;
    public float startDeg = 0;
    public float distance = 9;

    public bool detected;
    public string[] layers = new string[] { "Player", "Wall", "Box" };
    private int layerMask;

    private GameObject player;
    private Transform target;

    public enum EnemyType { VisionChaser, PathFollower }
    public EnemyType currentEnemyType;

    public bool shouldShake = false;

    // enemy state
    public enum EnemyState { Waiting, Patrolling, Chasing, Alert }
    public EnemyState currentEnemyState;

    public Shake_Trigger Shake;
    
    public Vector3 lastSeenPoint;

    void Start() {
        detected = false;
        layerMask = LayerMask.GetMask(layers);

        player = GameObject.Find("Player_Prototype");
        target = player.GetComponent<Transform>();

        if (GetComponent<EnemyPathConnector>() == null) {
            // visionchasers can either be waiting, chasing, or alert
            currentEnemyType = EnemyType.VisionChaser;
            currentEnemyState = EnemyState.Waiting;
        } else {
            // unlike visionchasers, pathfollowers start with patrolling.
            // once pathfollowers see and chase after the player, they basically become visionchasers. same thing, I guess
            currentEnemyType = EnemyType.PathFollower;
            currentEnemyState = EnemyState.Patrolling;
        }
    }

    void Update() {
        // lord forgive me for the spaghetti i unleash upon this project
        switch (currentEnemyState) {
            case EnemyState.Waiting:
                // check to see if player is in sight.
                // if they are, set lastSeenPoint to the player's position, set currentEnemyState to Chasing.
                // otherwise, don't do anything
                if (playerInSight()) {
                    lastSeenPoint = target.position;
                    currentEnemyState = EnemyState.Chasing;
                }
                break;
            case EnemyState.Patrolling:
                // exactly the same as waiting, except follow a path. check to see if the player is in sight.
                // if they are, set lastSeenPoint to the player's position, set currentEnemyState to Chasing.
                // otherwise, follow the next point on the path.
                if (playerInSight()) {
                    lastSeenPoint = target.position;
                    currentEnemyState = EnemyState.Chasing;
                } else {
                    // TODO: follow points
                }
                break;
            case EnemyState.Chasing:
                // check to see if the player is in sight.
                // if they are, set lastSeenPoint to the player's position.
                // otherwise, continue on to lastSeenPoint.
                // if the enemy is already at lastSeenPoint, go into Alert
                if (playerInSight()) {
                    lastSeenPoint = target.position;
                }                
                // move towards last seen point
                transform.position = Vector3.MoveTowards(transform.position, lastSeenPoint, moveSpeed * Time.deltaTime);

                Vector3 enemyPos = transform.position;
                Vector3 playerPos = target.position;
                if (Vector3.Distance(playerPos, enemyPos) > 0.1f) currentEnemyState = EnemyState.Alert;

                break;
            case EnemyState.Alert:
                // exactly the same as waiting, but with a wider FOV. the enemy is in a higher state of awareness.
                // increase FOV, increase vision distance, change currentEnemyState to Waiting.
                // fovDegrees = 360;
                // distance = Mathf.Max(distance + 0.2f, 10);
                currentEnemyState = EnemyState.Waiting;
                break;
        }

        
    }

    bool playerInSight() {
        // check if they're distance enough
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = target.position;
        if (Vector3.Distance(playerPos, enemyPos) > distance) return false;

        /* raycast!
         * shoot ray to detect walls or the player, whichever it hits first
         * i am almost certain some unfortunate soul will happen upon this code, and write off the entire section as "physics stuff, don't touch"
         * so, I'll explain it step by step!
         * 
         * 1. we check to see if the player is in viewing range of the enemy.
         *      if the player isn't even in range, we don't need to bother doing any of that weird raycasting stuff
         *      
         * 2. If the player IS in range, we need to see if the line of sight is blocked by any walls.
         *      Shoot a raycast from the enemy to the player. A raycast seems very scary, but in small words, it tells us if it hit anything.
         *      
         *               Raycast        | Wall
         *      Enemy ----------------> |             Player
         *                              |
         *      
         *      This way, we don't have enemies tracking the player through walls or whatever.
         *      For more reading: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
         *      
         * 3. if the raycast DID hit the player, we chase 'em down!
         * 
         * I hope my explanation was detailed enough. I've labelled where the points are to help understanding.
         */

        // 1. check if player is in viewing range of the enemy
        Vector3 enemyToPlayer = playerPos - enemyPos;
        startDeg %= 360;
        float endDeg = (startDeg + fovDegrees) % 360;
        float playerDeg = Quaternion.FromToRotation(Vector3.left, enemyPos - playerPos).eulerAngles.z;
        bool inFov = (startDeg < endDeg) ?
            (startDeg <= playerDeg && playerDeg <= endDeg) : // normal case
            (startDeg <= playerDeg || playerDeg <= endDeg); // end wraps around to 0

        // this isn't required, but it's just nice.
        // draw rays so you can visually see the enemy's field of view.
        Debug.DrawRay(
            enemyPos,
            enemyToPlayer.normalized * distance,
            inFov ? Color.green : Color.red
        );
        Debug.DrawRay(enemyPos, Quaternion.AngleAxis(startDeg, Vector3.forward) * Vector3.right * distance, Color.yellow);
        Debug.DrawRay(enemyPos, Quaternion.AngleAxis(endDeg, Vector3.forward) * Vector3.right * distance, Color.yellow);

        // if the player isn't in range, we don't have to do fancy stuff.
        if (!inFov) return false;

        // 2. If the player IS in range, we need to see if the line of sight is blocked by any walls.
        RaycastHit2D hit = Physics2D.Raycast(enemyPos, enemyToPlayer, distance, layerMask);

        // 3. If the raycast hit the player, chase them!
        detected = (hit.collider == null) ? false : (hit.collider.gameObject.tag == "Player");

        if (shouldShake) {
            Shake.IsShaking(detected);
        }

        return detected;
    }
}
