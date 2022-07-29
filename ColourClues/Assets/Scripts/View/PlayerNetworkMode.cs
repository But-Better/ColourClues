using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create a Singleton from current network instance 
/// </summary>
public class PlayerNetworkMode : MonoBehaviour
{
    [field: SerializeField] private bool ServerOrClient { get; set; }

    public bool status { get; private set; }

    public void Change(bool mode)
    {
        Debug.Log($"Change Server to Client mode status: {mode}");
        ServerOrClient = mode;
        status = mode;
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
