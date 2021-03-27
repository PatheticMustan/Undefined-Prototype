using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPushScript : MonoBehaviour
{

    public GameObject door;
    public bool open;

    void Start()
    {
        open = false;
    }



    void OnTriggerEnter2D(Collider2D col)
    {

        if ((col.gameObject.tag.Equals("Crate") || col.gameObject.tag.Equals("Player")))
            {

            open = !open;
            door.SetActive(!open);
            GetComponent<SpriteRenderer>().color = open ? new Color(0x00, 0xFF, 0x00) : new Color(0xFF, 0x00, 0x00);
        }
      
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if ((col.gameObject.tag.Equals("Crate") || col.gameObject.tag.Equals("Player")))
        {
            OnTriggerEnter2D(col);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Crate")) 
        {
            open = false;
        }
    }
}

