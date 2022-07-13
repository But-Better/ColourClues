using System;
using UnityEngine;

public class OnClickReceiver : MonoBehaviour {

    public Action<int> onClickEvent;
    public int index;

    private void OnMouseDown() {
        onClickEvent?.Invoke(index);
    }
}