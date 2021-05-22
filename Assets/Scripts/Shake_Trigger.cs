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
        CamAni.SetBool("Shake", AmShaking);
    }

    public void IsShaking(bool Shaking)    
    {

        AmShaking = Shaking;

    }

}

