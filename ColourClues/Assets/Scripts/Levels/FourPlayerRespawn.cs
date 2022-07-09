using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourPlayerRespawn : MonoBehaviour
{

    public GameObject RedPlayer;
    public GameObject GreenPlayer;
    public GameObject BluePlayer;
    public GameObject YellowPlayer;

    public Vector3 respawnLocationRed;
    public Vector3 respawnLocationGreen;
    public Vector3 respawnLocationBlue;
    public Vector3 respawnLocationYellow;

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

            case "BluePlayer":
            player.transform.position = respawnLocationBlue;
            break;

            case "YellowPlayer":
            player.transform.position = respawnLocationYellow;
            break;

        }
    }
}
