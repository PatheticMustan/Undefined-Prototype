using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {
    public KeyDoor[] doors;

    void Start() {

    }

    void OnCollisionEnter2D(Collision2D collision) {
        // loop through all the doors, call foundKey() on them
        if (collision.gameObject.tag == "Player") {
            for (int i = 0; i < doors.Length; i++) {
                doors[i].foundKey();
            }
        }

        // destroy the key
        Destroy(gameObject);
    }
}
