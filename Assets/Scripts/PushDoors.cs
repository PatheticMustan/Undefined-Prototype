using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDoors : MonoBehaviour
{
    public float openDistance = 1.0f;

    public GameObject left;
    public GameObject right;

    public GameObject leftPivot;
    public GameObject rightPivot;

    private bool update;
    public bool open;

    void Start()
    {
        update = false;

    }

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectsWithTag("Player")[0].transform.position);

        left.SetActive(dist > openDistance);
        right.SetActive(dist > openDistance);

        // I hate doors
        /*if (dist > openDistance) {
            if (open) {
                updateDoors();
            }
        } else {
            if (!open) {
                updateDoors();
            }
        }

        if (update) {
            update = false;

            // rotate around pivot
            if (!open) {
                left.transform.RotateAround(leftPivot.transform.position, Vector3.up, 80);
                right.transform.RotateAround(rightPivot.transform.position, Vector3.up, -80);
            } else {
                left.transform.RotateAround(leftPivot.transform.position, Vector3.up, -80);
                right.transform.RotateAround(rightPivot.transform.position, Vector3.up, 80);
            }
        }*/
    }

    /*public void updateDoors() { 
    
    }*/
}
