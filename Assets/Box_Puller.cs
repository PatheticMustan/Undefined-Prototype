using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Puller : MonoBehaviour
{
    public bool IsPulling;
    public GameObject Player;
    public GameObject Boxs;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (IsPulling == true)
        {
            Debug.Log("Plz Work");
            Player.transform.SetParent(Boxs.transform);
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Crate"))
        {
            IsPulling = true;
        }

    }

   private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Crate"))
       {
            IsPulling = false;
        }

    }
}
