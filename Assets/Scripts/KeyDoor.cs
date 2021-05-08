using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    // by default, 1.
    public int keysRequired = 1;

    void Start() {}

    // Update is called once per frame
    void Update() {}

    public void foundKey() {
        keysRequired--;
        if (keysRequired <= 0) {
            // TODO: play door open sound
            gameObject.SetActive(false);
        }
    }
}
