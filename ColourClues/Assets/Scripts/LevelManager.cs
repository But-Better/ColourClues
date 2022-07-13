using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Models;
using Event;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : NetworkBehaviour {

    [SyncVar] [SerializeField] private List<GameObject> availablePlayer = new();

    [SyncVar] [SerializeField] private int playerNeededToFinishTheGame;
    [SyncVar] [SerializeField] private AlphaValueEvent alphaValueEvent;
    
    [SerializeField] private ColorClueEvent assignLevelColorEvent;

    [SyncVar] [SerializeField] private GameObject genericPlayerPrefab;
    
    private List<ColorOwner> goalReachedPlayers = new();

    public void ColorOwnerEnterGoal(ColorOwner colorOwner) {
        if(!goalReachedPlayers.Contains(colorOwner)) {
            goalReachedPlayers.Add(colorOwner);
        }

        if(goalReachedPlayers.Count >= playerNeededToFinishTheGame) {
            LevelSolved();
        }
    }

    public void ColorOwnerLeaveGoal(ColorOwner colorOwner) {
        if(goalReachedPlayers.Contains(colorOwner)) {
            goalReachedPlayers.Remove(colorOwner);
        }
    }

    private void LevelSolved() {
        print("Level solved");

        StartCoroutine(Fade());
    }
    
    public Tuple<GameObject, Transform> GetAvailablePlayer(NetworkConnectionToClient conn) {
        var randomPlayerIndex = Random.Range(0, availablePlayer.Count);
        
        var spawnPoint = availablePlayer[randomPlayerIndex];
        
        var player = genericPlayerPrefab;

        availablePlayer.Remove(player);
        
        var neededColor = spawnPoint.GetComponent<ColorOwner>().ColorClue;

        if (isLocalPlayer)
        {
            assignLevelColorEvent.Raise(neededColor);
        }

        player.GetComponent<ColorOwner>().ColorClue = neededColor;
        
        return new Tuple<GameObject, Transform>(player, spawnPoint.transform);
    }

    public int MaxAvailablePlayers()
    {
        return availablePlayer.Count;
    }
    
    private IEnumerator Fade() {
        var alpha = 0f;

        while(alpha < 1f) {
            alpha += Time.deltaTime / 2;
            alphaValueEvent.Raise(new AlphaValue(alpha));
            yield return null;
        }
    }
}