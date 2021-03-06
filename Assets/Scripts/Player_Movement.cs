using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {
    // [SerializeField] public Player_Light fieldofview;
    private Rigidbody2D rb;
    private Vector2 Movement;

    public GameObject deathScreenGameObject;
    public bool dead;

    [Space()]
    [Header("Stamina")]

    public float maxStamina;
    public float stamina;
    public float staminaConsumption;
    public float staminaRegeneration;

    [Space()]
    [Header("Light")]

    public Transform pointLight;

    [Space()]
    [Header("Movement")]

    public float moveSpeed = 5f;
    //public Transform movePoint;
    //public LayerMask WhatStopsPlayer;

    void Start() {
       

        maxStamina = 100;
        stamina = 100;
        staminaConsumption = 0.2f;
        staminaRegeneration = 0.4f;

        rb = GetComponent<Rigidbody2D>();

        //grid control move 
        //movePoint.parent = null;

    }


    void Update() {
        if (!dead) {
            //player input

            Movement.x = Input.GetAxisRaw("Horizontal");
            Movement.y = Input.GetAxisRaw("Vertical");        

            }
            //light input 
        if (Input.GetKey(KeyCode.Q)) {
                pointLight.Rotate(new Vector3(0, 0, 1.5f));
            }
        if (Input.GetKey(KeyCode.E)) {
                pointLight.Rotate(new Vector3(0, 0, -1.5f));
            }


         else if (dead){
            deathScreenGameObject.GetComponent<CanvasGroup>().alpha = Mathf.Min(1, deathScreenGameObject.GetComponent<CanvasGroup>().alpha + 0.01f);
        }


        // regen stamina
       // float staminaSpeed = 1f;
       // stamina = Mathf.Min(maxStamina, stamina + staminaRegeneration);
       // if (Input.GetKey(KeyCode.LeftShift) && stamina >= staminaConsumption) {
        //    stamina -= staminaConsumption;
       //     staminaSpeed = 2f;
        //}

        // movement
        rb.MovePosition(rb.position + Movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            dead = true;
        }
    }
}
