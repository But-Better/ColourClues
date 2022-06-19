using UnityEngine;
using UnityEngine.Events;
public class ActivatableEvent : ActivatableObject {

    [SerializeField] private UnityEvent<ColorOwner> activate;
    [SerializeField] private UnityEvent<ColorOwner> deactivate;

    public override void Activate(ColorOwner colorOwner) {
        activate?.Invoke(colorOwner);
    }

    public override void Deactivate(ColorOwner colorOwner) {
        deactivate?.Invoke(colorOwner);
    }
}