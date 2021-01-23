using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
   // [SerializeField] public Player_Light fieldofview;
    private Rigidbody2D rb;
    private Vector2 Movement;

    public float MoveSpeed;

    [Space()]
    [Header("Stamina")]

    public float maxStamina;
    public float stamina;
    public float staminaConsumption;
    public float staminaRegeneration;
    
    void Start()
    {
        MoveSpeed = 3;

        maxStamina = 100;
        stamina = 100;
        staminaConsumption = 2;
        staminaRegeneration = 0.4f;

        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // input
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");
        Movement = Movement.normalized;
    }
    
    
    void FixedUpdate()
    {
        // movement
        //fieldofview.Setorgin(transform.position);

        float staminaSpeed = 1f;

        // regen stamina
        stamina = Mathf.Min(maxStamina, stamina + staminaRegeneration);
        if (Input.GetKey(KeyCode.LeftShift) && stamina >= staminaConsumption)
        {
            stamina -= staminaConsumption;
            staminaSpeed = 2;
        }

        rb.MovePosition(rb.position + Movement * MoveSpeed * staminaSpeed * Time.fixedDeltaTime);

    }
}
