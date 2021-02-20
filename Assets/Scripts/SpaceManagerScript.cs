using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManagerScript : MonoBehaviour {
    // a boolean to denote if there is an impassable wall
    public bool[][] passable;

    public delegate void multiDelegateTrigger();
    // triggers for buttons, possibly cutscenes...?
    public multiDelegateTrigger[,] triggers;

    void Start() {
        // loadLevel();
    }

    // Update is called once per frame
    void Update() {

    }

    public void loadLevel(int width, int length) {
        triggers = new multiDelegateTrigger[width, length];
    }

    public multiDelegateTrigger getTrigger(int x, int y) {
        return triggers[x, y];
    }
}
