using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceManagerScript : MonoBehaviour {
    // a boolean to denote if there is an impassable wall
    // instead of adding colliders on the player and wall tilemap, we can just check passable before moving.
    // this also allows us to "open" doors by setting passable[x,y] to true
    public bool[,] passable;

    public delegate void multiDelegateTrigger();
    // triggers for buttons, possibly cutscenes...?
    public multiDelegateTrigger[,] triggers;

    void Start() {
        // loadLevel();
    }

    // Update is called once per frame
    void Update() {

    }

    // we're using delegates to make callbacks easier.
    // the code is the way it is because everybody left for FGD, and the solo-dev isn't experienced enough to make sensible decisions
    // usage:
    // getTrigger(x, y) += callbackFunction;
    // 
    // note the lack of paren's on callbackFunction
    // I briefly considered "UnityActions", but nah
    //
    // more reading:
    // https://docs.unity3d.com/ScriptReference/Events.UnityAction.html
    // https://learn.unity.com/tutorial/delegates#5c894658edbc2a0d28f48aee
    // https://stackoverflow.com/questions/12567329/multidimensional-array-vs
    public void loadLevel(int width, int length) {
        // somehow figure out how to parse the wall tilemap into passable
        passable = new bool[width, length];
        // triggers can be set with getTrigger(int, int)
        triggers = new multiDelegateTrigger[width, length];
    }

    public multiDelegateTrigger getTrigger(int x, int y) {
        return triggers[x, y];
    }
}
