﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject door;
    public bool open;

    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {



    }

    //void OnTriggerEnter2D(Collider2D col)
    //{
       // open = !open;
       // door.SetActive(!open);
        //GetComponent<SpriteRenderer>().color = open ? new Color(0x00, 0xFF, 0x00) : new Color(0xFF, 0x00, 0x00);
        
    //}

    void OnTriggerEnter2D(Collider2D col)
    {



        if (col.gameObject.tag.Equals("Crate"))
        {
            open = !open;
            door.SetActive(!open);
            GetComponent<SpriteRenderer>().color = open ? new Color(0x00, 0xFF, 0x00) : new Color(0xFF, 0x00, 0x00);

        }


        if (col.gameObject.tag.Equals("Player"))
        {
            open = !open;
            door.SetActive(!open);
            GetComponent<SpriteRenderer>().color = open ? new Color(0x00, 0xFF, 0x00) : new Color(0xFF, 0x00, 0x00);

        }

    }

    void OnTriggerExit2D(Collider2D col) {

        
        door.SetActive(open);
  
    }

}