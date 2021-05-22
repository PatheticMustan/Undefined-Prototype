using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_Trigger : MonoBehaviour
{
    public bool AmShaking;
    public Animator CamAni;

    void Start()
    {
        AmShaking = false;
    }
    
    void Update()
    {
        if (AmShaking == false) 
        {
            CamAni.SetBool("Shake", false);
        }
        
        if (AmShaking == true)
        {
            CamAni.SetBool("Shake", true);
        }
    
    }

    public void IsShaking(bool Shaking)    
    {

        AmShaking = Shaking;

    }

}

