using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
   // [SerializeField] public Player_Light fieldofview;
    Rigidbody2D rb;
    public float MoveSpeed = 5;
    Vector2 Movement;
    
    
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();


    }

 
    
    
    
    void FixedUpdate()
    {

        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        Movement = Movement.normalized;
       // fieldofview.Setorgin(transform.position);

        rb.MovePosition(rb.position + Movement * MoveSpeed * Time.fixedDeltaTime);
    }

}
