using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;

public class AvailablePlayerProvider : NetworkBehaviour
{
    [SerializeField] private List<GameObject> AvaliablePlayer = null;
    
    private SyncList<GameObject> _availablePlayer = new SyncList<GameObject>();

    public List<GameObject> AvailablePlayer => _availablePlayer.ToList();

    public GameObject GetAvailablePlayer() {
        
        if (_availablePlayer.Count == 0)
        {
            _availablePlayer = new SyncList<GameObject>();
            foreach (var availablePlayer in AvailablePlayer)
            {
                _availablePlayer.Add(availablePlayer);
            }
        }
        
        var randomPlayerIndex = Random.Range(0, _availablePlayer.Count);
        
        var playerObject = _availablePlayer[randomPlayerIndex];

        _availablePlayer.Remove(playerObject);

        return playerObject;
    }
}
