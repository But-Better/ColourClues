using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EmoteController : MonoBehaviour {

    [Serializable]
    public class EmoJiData {
        [SerializeField] private Sprite sprite;
        [SerializeField] private Vector2 direction;

        public Sprite Sprite => sprite;
        public Vector2 Direction => direction;
    }

    [SerializeField] private GameObject spritePrefab;
    [SerializeField] private GameObject emojiPrefab;
    [SerializeField] private float emojiYOffset = 1f;
    [SerializeField] private float openingDistance = 10f;
    [SerializeField] private float startRatio = 0.1f;
    [SerializeField] private float openingSpeed = 1f;
    [SerializeField] private List<EmoJiData> emojiDatas;

    private List<GameObject> buttons = new List<GameObject>();

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(buttons.Count == 0) {
                StartCoroutine(OpenEmojies());
            } else {
                CloseEmojies();
            }
        }
    }

    private IEnumerator OpenEmojies() {
        if(buttons.Count != 0) {
            yield break;
        }

        var parent = Instantiate(new GameObject());
        parent.AddComponent<FollowPlayerScript>().playerObject = gameObject;

        for(int index = 0; index < emojiDatas.Count; index++) {
            var emojiData = emojiDatas[index];
            var button = Instantiate(spritePrefab, parent.transform, false);

            button.transform.localPosition = emojiData.Direction * (openingDistance * startRatio);
            button.transform.localScale = new Vector3(startRatio, startRatio, startRatio);

            button.GetComponentInChildren<SpriteRenderer>().sprite = emojiData.Sprite;
            button.GetComponentInChildren<OnClickReceiver>().onClickEvent = ShowEmoji;
            button.GetComponentInChildren<OnClickReceiver>().index = index;


            buttons.Add(button);
        }

        var openingState = startRatio;
        while(openingState < 1f) {
            openingState += openingState * (Time.deltaTime * openingSpeed);

            if(openingState > 1f) {
                openingState = 1f;
            }

            for(int index = 0; index < emojiDatas.Count; index++) {
                var button = buttons[index];
                var emojiData = emojiDatas[index];

                button.transform.localPosition = emojiData.Direction * (openingDistance * openingState);
                button.transform.localScale = new Vector3(openingState, openingState, openingState);

                buttons.Add(button);
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void ShowEmoji(int index) {
        CloseEmojies();

        var emojiData = emojiDatas[index];

        var emoji = Instantiate(emojiPrefab, transform, false);
        emoji.GetComponent<SpriteRenderer>().sprite = emojiData.Sprite;
        emoji.transform.localPosition = Vector3.up * emojiYOffset;
    }

    private void CloseEmojies() {
        foreach(var button in buttons) {
            Destroy(button.gameObject);
        }

        buttons.Clear();
    }
}