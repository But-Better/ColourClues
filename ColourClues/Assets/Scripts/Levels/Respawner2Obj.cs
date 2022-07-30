using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A respawn script for two objects
/// if an object triggers the barrier it will be teleportet back to
/// respawnLocationObj1 / respawnLocationObj2
/// </summary>

public class Respawner2Obj : MonoBehaviour
{

    public GameObject object1;
    public GameObject object2;

    private string object1Name = "";
    private string object2Name = "";

    public Vector3 respawnLocationObj1;
    public Vector3 respawnLocationObj2;

    // Start is called before the first frame update
    void Start()
    {
        object1Name = object1.name;
        object2Name = object2.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){

        GameObject triggeredObject = col.gameObject;

        Debug.Log("Respawn Collision Detected" + triggeredObject.name);
        
        respawn(triggeredObject);
        
    }

    private void respawn(GameObject obj){

        if(obj.name == object1Name) obj.transform.position = respawnLocationObj1;
        if(obj.name == object2Name) obj.transform.position = respawnLocationObj2;
    }
}
