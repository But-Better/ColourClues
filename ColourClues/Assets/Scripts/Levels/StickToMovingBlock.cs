using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script makes a Gameobjects position defined by the moving object its standing on
/// </summary>

public class StickToMovingBlock : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        col.collider.transform.SetParent(transform);
    }

    void OnCollisionExit2D(Collision2D col){
        col.collider.transform.SetParent(null);
    }
}
