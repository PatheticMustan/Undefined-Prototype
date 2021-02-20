using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManagerScript : MonoBehaviour
{
    // a boolean to denote if there is an impassable wall
    public bool[][] passable;
    // triggers for buttons, possibly cutscenes...?
    public bool[][] triggers;

    public delegate void CallbackDelegate();
    public CallbackDelegate

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void registerTrigger(int x, int y, delegate callback) { 
        triggers
    }
}
