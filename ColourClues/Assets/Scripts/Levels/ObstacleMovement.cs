using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves an Gameobject on the x Axis from
/// leftReturnPosition to rightReturnPosition and back
/// speed controls the speed of the movement
/// </summary>

public class ObstacleMovement : MonoBehaviour
{

    public float speed;
    public float leftReturnPosition; 
    public float rightReturnPosition; 

    private Vector3 dir = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(dir*speed*Time.deltaTime);
 
        if(transform.position.x <= leftReturnPosition){ 
           dir = Vector3.right;
        }else if(transform.position.x >= rightReturnPosition){
           dir = Vector3.left;
        }
    }
}
