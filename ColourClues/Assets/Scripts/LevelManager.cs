using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DefaultNamespace.Models;
using Event;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _startingAvailablePlayer = new();

    [SerializeField] private int playerNeededToFinishTheGame;
    [SerializeField] private AlphaValueEvent alphaValueEvent;
    
    [SerializeField] private ColorClueEvent assignLevelColorEvent;

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
    
    public GameObject GetAvailablePlayer(bool getFirst)
    {
        var playerCharacter = getFirst ? 
            _startingAvailablePlayer[0] : 
            _startingAvailablePlayer[_startingAvailablePlayer.Count - 1];
        
        var color = playerCharacter.GetComponent<ColorOwner>().ColorClue;

        assignLevelColorEvent.Raise(color);

        _startingAvailablePlayer.Remove(playerCharacter);
        
        return playerCharacter;
    }

    public int MaxAvailablePlayers()
    {
        return _startingAvailablePlayer.Count;
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