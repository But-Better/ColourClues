using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using UnityEngine;

/// <summary>
/// Adds an additional Interface between the <see cref="CustomLevelLoadNetworkManager"/>
/// and the <see cref="LevelManager"/>
/// </summary>
[RequireComponent(typeof(CustomLevelLoadNetworkManager))]
public class LevelManagerImport : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager = null;

    private CustomLevelLoadNetworkManager _mCustomLevelLoadNetworkManager;
    
    private void Start()
    {
        _mCustomLevelLoadNetworkManager = GetComponent<CustomLevelLoadNetworkManager>();

        var maxAvailablePlayers = levelManager.MaxAvailablePlayers();
        
        _mCustomLevelLoadNetworkManager.SetMinPlayer(maxAvailablePlayers);
    }
}
