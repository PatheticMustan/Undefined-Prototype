using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnPlay : MonoBehaviour {
    // what did you expect?
    void Start() {
        gameObject.SetActive(false);
    }
}