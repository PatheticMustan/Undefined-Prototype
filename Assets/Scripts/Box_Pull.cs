using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Pull : MonoBehaviour
{
    public float distance_pull = 1f;
    public LayerMask boxMask;
    GameObject box;

    void Start()
    {
 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine (transform.position,(Vector2) transform.position +  Vector2.right * transform.localScale.x * distance_pull);
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance_pull, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Crate" && Input.GetKeyDown(KeyCode.E))
        {

            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;
           
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            
        }
    
    }
}
