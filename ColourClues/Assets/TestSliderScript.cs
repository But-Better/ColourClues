using DefaultNamespace.Models;
using Event;
using UnityEngine;
public class TestSliderScript : MonoBehaviour {
    [SerializeField] private AlphaValueEvent alphaValueEvent;

    public void OnValueChanged(float alpha) {
        alphaValueEvent?.Raise(new AlphaValue(alpha));
    }
}