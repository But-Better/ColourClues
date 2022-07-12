using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworkMode : MonoBehaviour
{
    public static PlayerNetworkMode Instance { get; private set; }
    [field: SerializeField] public bool isServer { get; private set; }

    public void Change(bool mode)
    {
        Debug.Log($"Change Server to Client mode status: {mode}");
        isServer = mode;
    }

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