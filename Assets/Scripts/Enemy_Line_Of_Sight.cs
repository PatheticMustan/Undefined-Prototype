using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Line_Of_Sight : MonoBehaviour
{
    [SerializeField]
    Transform CastPoint;

    [SerializeField]
    Transform player;

    [SerializeField]
    float agrorange;
    
    [SerializeField]
    float movespeed;

    Rigidbody2D rb2d;

    void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
 
    }

    void Update()
    {

        if (CanSeePlayer(agrorange))
        {

            ChasePlayer();

        }
        else
        {

            StopChasingPlayer();
        
        }



    }

    void ChasePlayer() 
    {

        if (transform.position.x < player.position.x)
        {

            //enemt on left side of player 
            rb2d.velocity = new Vector2(movespeed, 0);
            transform.localScale = new Vector2(1, 1);

        }
        else
        {

            //enemt on right side of player 
            rb2d.velocity = new Vector2(-movespeed, 0);
            transform.localScale = new Vector2(-1, 1);

        }

            


    
    }

    void StopChasingPlayer() 
    {

        rb2d.velocity = new Vector2(0, 0); 
    
    }

    bool CanSeePlayer(float distance) 
    {
        bool val = false;
        float castDist = distance;

        Vector2 endPos = CastPoint.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(CastPoint.position, endPos, 1 << LayerMask.NameToLayer("Action") );

        if (hit.collider != null) 
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {

                val = true;


            }
            else
            {

                val = false;
            
            }

            
        }
        return val;

    }
}
