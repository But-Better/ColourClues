using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Models;
using Event;
using UnityEngine;
public class LevelManager : MonoBehaviour {

    [SerializeField] private int playerNeededToFinishTheGame;
    [SerializeField] private AlphaValueEvent alphaValueEvent;

    private List<ColorOwner> goalReachedPlayer = new List<ColorOwner>();

    public void RegisterColorOwner(ColorOwner colorOwner) {
        if(!goalReachedPlayer.Contains(colorOwner)) {
            goalReachedPlayer.Add(colorOwner);
        }

        if(goalReachedPlayer.Count >= playerNeededToFinishTheGame) {
            LevelSolved();
        }
    }

    public void DeregisterColorOwner(ColorOwner colorOwner) {
        if(goalReachedPlayer.Contains(colorOwner)) {
            goalReachedPlayer.Remove(colorOwner);
        }
    }

    private void LevelSolved() {
        print("Level solved");

        StartCoroutine(Fade());
    }

    private IEnumerator Fade() {
        float alpha = 0f;

        while(alpha < 1f) {
            alpha += Time.deltaTime / 2;
            alphaValueEvent.Raise(new AlphaValue(alpha));
            yield return null;
        }
    }
}