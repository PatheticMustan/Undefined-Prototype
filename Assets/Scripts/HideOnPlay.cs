using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class HideOnPlay : MonoBehaviour {
    // what did you expect?
    void Start() {
        GetComponent<CanvasGroup>().alpha = 0;
    }
}