using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpaceManagerScript : MonoBehaviour {
    // a boolean to denote if there is an impassable wall
    // instead of adding colliders on the player and wall tilemap, we can just check passable before moving.
    // this also allows us to "open" doors by setting passable[x,y] to true
    public bool[,] passable;

    public delegate void multiDelegateTrigger();
    // triggers for buttons, possibly cutscenes...?
    public multiDelegateTrigger[,] triggers;

    // assign in inspector
    public Tilemap wallTM;

    void Start() {
        Debug.Log(wallTM.origin);
        Debug.Log(wallTM.size);
        
        loadLevel(wallTM);

        // why is the grid's origin at (-20, -13, 0)?????????
        // trying to align wallTilemap origin to (0, 0, 0), if you can figure out how, please dm me.
        //
        //GridLayout gridLayout = wallTM.transform.parent.GetComponentInParent<Grid>();
        //Debug.Log(gridLayout.CellToWorld(wallTM.origin)); 
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
    public void loadLevel(Tilemap levelTilemap) {
        Vector3Int origin = levelTilemap.origin;
        Vector3Int size = levelTilemap.size;

        int width = size.x,
            length = size.y;

        // parse wall tilemap into passable 2d array
        passable = new bool[width, length];

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < length; y++) {
                passable[x, y] = levelTilemap.HasTile(origin + new Vector3Int(x, y, 0));
            }
        }

        // triggers can be set with getTrigger(int, int)
        triggers = new multiDelegateTrigger[width, length];

        Debug.Log(passable);
    }

    public multiDelegateTrigger getTrigger(int x, int y) {
        return triggers[x, y];
    }
}
