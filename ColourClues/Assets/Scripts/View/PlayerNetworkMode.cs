using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkMode : MonoBehaviour
{
    [field: SerializeField] private bool ServerOrClient { get; set; }

    public void Change(bool mode)
    {
        ServerOrClient = mode;
    }
        
    public static PlayerNetworkMode Instance { get; private set; }

    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
}

