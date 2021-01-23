using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{

    public float speed;
    public Transform target;
    public bool overlapping;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

   
    void Update()
    {
        if (overlapping == true)
        {
            speed = 1;
        }





        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
  

}


