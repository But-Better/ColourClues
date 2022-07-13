using System;
using UnityEngine;

public class LifeTimeComponent : MonoBehaviour {

    [SerializeField] private float timeAlive;

    private float timer = 0;

    private void Update() {
        timer += Time.deltaTime;
        if(timer > timeAlive) {
            Destroy(gameObject);
        }
    }
}