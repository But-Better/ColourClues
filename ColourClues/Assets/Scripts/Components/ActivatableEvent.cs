using UnityEngine;
using UnityEngine.Events;
public class ActivatableEvent : ActivatableObject {

    [SerializeField] private UnityEvent activate;
    [SerializeField] private UnityEvent deactivate;

    public override void Activate() {
        activate?.Invoke();
    }

    public override void Deactivate() {
        deactivate?.Invoke();
    }
}