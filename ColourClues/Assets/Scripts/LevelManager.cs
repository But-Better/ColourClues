using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Models;
using Event;
using Mirror;
using UnityEngine;
public class LevelManager : NetworkBehaviour {

    [SerializeField] private List<GameObject> availablePlayer = new List<GameObject>();

    [SerializeField] private int playerNeededToFinishTheGame;
    [SerializeField] private AlphaValueEvent alphaValueEvent;
    [SerializeField] private ColorClueEvent assignLevelColorEvent;

    private List<ColorOwner> goalReachedPlayers = new List<ColorOwner>();

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

    public GameObject GetAvailablePlayer() {
        var randomPlayerIndex = Random.Range(0, availablePlayer.Count);

        var player = availablePlayer[randomPlayerIndex];
        availablePlayer.Remove(player);

        assignLevelColorEvent.Raise(player.GetComponent<ColorOwner>().ColorClue);

        return player;
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