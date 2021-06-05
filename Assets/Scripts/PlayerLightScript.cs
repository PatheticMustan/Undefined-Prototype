using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerLightScript : MonoBehaviour {
    public Light2D light;
    public float min = 1,
        max = 7,
        degeneracyRate = 0.03f;

    void Start() {
        light.pointLightOuterRadius = max;
    }


    void Update() {
        light.pointLightOuterRadius = Mathf.Max(min, light.pointLightOuterRadius - (degeneracyRate * Time.deltaTime));
    }

    public void UseBattery() {
        light.pointLightOuterRadius = max;
    }
}
