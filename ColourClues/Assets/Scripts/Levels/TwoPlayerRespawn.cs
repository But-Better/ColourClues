using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class takes 2 possible players and 2 possible respawn locations
/// Combined with a trigger owning Gameobject
/// a player who triggers the object will be teleported to the according respawn location
/// RedPlayer -> respawnLocationRed | GreenPlayer -> respawnLocationGreen
/// </summary>

public class TwoPlayerRespawn : MonoBehaviour
{

    public GameObject RedPlayer;
    public GameObject GreenPlayer;

    public Vector3 respawnLocationRed;
    public Vector3 respawnLocationGreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){

        GameObject triggeredPlayer = col.gameObject;

        Debug.Log("Respawn Collision Detected" + triggeredPlayer.name);
        
        respawn(triggeredPlayer);
        
    }

    private void respawn(GameObject player){
        switch(player.name){
            
            case "GreenPlayer":
            player.transform.position = respawnLocationGreen;
            break;

            case "RedPlayer":
            player.transform.position = respawnLocationRed;
            break;

        }
    }
}
