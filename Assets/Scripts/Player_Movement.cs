using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    // [SerializeField] public Player_Light fieldofview;
    private Rigidbody2D rb;
    private Vector2 Movement;

 

    [Space()]
    [Header("Stamina")]

    public float maxStamina;
    public float stamina;
    public float staminaConsumption;
    public float staminaRegeneration;

    public Transform pointLight;

    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask WhatStopsPlayer;

    void Start() {
       

        maxStamina = 100;
        stamina = 100;
        staminaConsumption = 2;
        staminaRegeneration = 0.4f;

        rb = GetComponent<Rigidbody2D>();

        //grid control move 
        movePoint.parent = null;

    }


    void Update() {
        //player input
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, movePoint.position) == 0f){

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {

                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, WhatStopsPlayer)) {
                    
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

                }
            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, WhatStopsPlayer)) { 
               
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

        }
        //light input 

        if (Input.GetKey(KeyCode.Q)) {
            pointLight.Rotate(new Vector3(0, 0, 1.5f));
        }
        if (Input.GetKey(KeyCode.E)) {
            pointLight.Rotate(new Vector3(0, 0, -1.5f));
        }
    }

    void FixedUpdate() {
        // regen stamina
        float staminaSpeed = 1f;
        stamina = Mathf.Min(maxStamina, stamina + staminaRegeneration);
        if (Input.GetKey(KeyCode.LeftShift) && stamina >= staminaConsumption) {
            stamina -= staminaConsumption;
            staminaSpeed = 2;
        }

        // movement
        rb.MovePosition(rb.position + Movement * moveSpeed * staminaSpeed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            Destroy(gameObject);
        }
    }
}
