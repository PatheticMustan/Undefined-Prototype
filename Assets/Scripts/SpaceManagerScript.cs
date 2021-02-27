using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpaceManagerScript : MonoBehaviour {
    /* list of big stuff
     * - bool[,] passable
     *     denotes if a tile is completely impassable (walls, level border)
     *     instead of adding colliders on the player and wall tilemap, we can just check passable before moving.
     *     this also allows us to "open" doors by setting passable[x,y] to true
     *     it's initialized by our wall tilemap
     *     
     *     - methods
     *         - bool hasTile(int x, int y)
     *              If the tile is a wall, lmao
     *         - Tile getTile(int x, int y)
     *              returns a tile in the wallTilemap
     *         - void setTile(Tile tile, bool passable, int x, int y)
     *              Sets a tile in the wallTilemap, like if we open a door
     *     
     * - GameObject[,] entities
     *     which entity is in that tile. anything that moves, or isn't static is an entity (player, enemies, crates, guards, cameras)
     *     even if the thing doesn't move, if it's anything interactive, it should probably be an entity
     *     entities should have a SpaceScript that lets them move around, and interact with the tilemap. It'll include related stuff
     *     
     *     eventually we'll need an entity script to manage its position, its entity type, and whatnot
     *     
     *     - methods
     *          - bool hasEntity(int x, int y)
     *              If a tile is in that tile
     *          - GameObject getEntity(int x, int y)
     *              Returns a GameObject in the tile. If it doesn't exist, it should return null
     *          - bool moveTile(int x, int y) ???????????/
     *          
     *          - void DestroyEntity(int x, int y)
     *              with the power of god itself, smite the entity where it stands
     * - 
     */
    public bool[,] passable;
    public GameObject[,] entities;

    public delegate void multiDelegateTrigger();
    // triggers for buttons, possibly cutscenes...?
    public multiDelegateTrigger[,] triggers;

    // assign in inspector
    public Tilemap wallTM;

    void Start() {
        loadLevel(wallTM, entities);

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
    public void loadLevel(Tilemap levelTilemap, GameObject[,] entitiesTilemap) {
        Vector3Int origin = levelTilemap.origin;
        Vector3Int size = levelTilemap.size;

        int width = size.x,
            length = size.y;

        // parse wall tilemap into passable 2d array
        passable = new bool[width, length];
        entitiesTilemap = new GameObject[width, length];

        // passable sensibly starts at the origin
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < length; y++) {
                passable[x, y] = levelTilemap.HasTile(origin + new Vector3Int(x, y, 0));
            }
        }

        // triggers can be set with getTrigger(int, int)
        triggers = new multiDelegateTrigger[width, length];

        Debug.Log(passable);
    }





    /*
    public bool hasTile(int x, int y) {
        return passable[x, y];
    }
    public Tile getTile(int x, int y) { 
    
    }
     *         - void setTile(Tile tile, bool passable, int x, int y)

    // get/register/remove triggers
    public multiDelegateTrigger getTrigger(int x, int y) {
        return triggers[x, y];
    }
    public void registerTrigger(multiDelegateTrigger trigger, int x, int y) {
        triggers[x, y] += trigger;
    }
    public void removeTrigger(multiDelegateTrigger trigger, int x, int y) {
        triggers[x, y] -= trigger;
    }



    public GameObject getEntity(int x, int y) {
        return entities[x, y];
    }
    public void registerEntity(GameObject entity, int x, int y) {
        if (entities[x, y] is null) {
            entities[x, y] = entity;
        } else {
            Debug.LogError("Dupe entity (" + entity.name + ") registered at [" + x + ", " + y + "]");
        }
    }
    public void removeTrigger(multiDelegateTrigger trigger, int x, int y) {
        triggers[x, y] -= trigger;
    }

    public bool moveToTile(Vector3 currentPosition, Vector3 targetPosition) {
        return true;
    }
    */
}
