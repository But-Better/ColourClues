using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Models;
using Event;
using UnityEngine;
public class LevelManager : MonoBehaviour {

    [SerializeField] private List<GameObject> availablePlayer = new List<GameObject>();
    [SerializeField] private int playerNeededToFinishTheGame;
    [SerializeField] private AlphaValueEvent alphaValueEvent;

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

    private GameObject GetAvailablePlayer() {
        var randomPlayerIndex = Random.Range(0, availablePlayer.Count);

        var player = availablePlayer[randomPlayerIndex];
        availablePlayer.Remove(player);

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