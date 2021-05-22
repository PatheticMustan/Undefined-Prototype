using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerLightScript : MonoBehaviour {
    public Light2D light;
    public float min = 1,
        max = 7,
        degeneracyRate = 0.05f;

    void Start() {
        light.pointLightOuterRadius = max;
    }


    void Update() {
        light.pointLightOuterRadius -= degeneracyRate * Time.deltaTime;
    }
}
