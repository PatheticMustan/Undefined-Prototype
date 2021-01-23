using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour {
    private Rigidbody2D rb;
    private Vector2 movement;

    public float moveSpeed;
    public Transform target;
    // public bool overlapping;
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        moveSpeed = 3;
    }


    void FixedUpdate() {
        // ah yes, broken code
        //movement = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        //rb.MovePosition(rb.position + movement);

        // move towards the player pos
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}


