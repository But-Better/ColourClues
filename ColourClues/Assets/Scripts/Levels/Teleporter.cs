using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script teleports any Gameobject that triggers the barrier
/// to the given position TeleportPosition
/// </summary>

public class Teleporter : MonoBehaviour
{
    public Vector3 TeleportPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        
        Debug.LogError("Teleporter Trigger Entered");
        col.transform.position = TeleportPosition;
    }
}
