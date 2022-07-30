using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script moves an Gameobject on the y Axis from
/// UPReturnPosition to DOWNReturnPosition and back
/// speed controls the speed of the movement
/// </summary>

public class ObstacleMovementUPDOWN : MonoBehaviour
{

    public float speed;
    public float UPReturnPosition; 
    public float DOWNReturnPosition; 

    private Vector3 dir = Vector3.down;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(dir*speed*Time.deltaTime);
 
        if(transform.position.y <= DOWNReturnPosition){ 
           dir *= -1;
        }else if(transform.position.y >= UPReturnPosition){
           dir *= -1;
        }
    }
}
