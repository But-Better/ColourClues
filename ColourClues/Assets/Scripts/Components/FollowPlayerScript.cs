using System;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour {
    public GameObject playerObject;

    private void Update() {
        transform.position = playerObject.transform.position;
    }
}