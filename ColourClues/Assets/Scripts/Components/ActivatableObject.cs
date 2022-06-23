using UnityEngine;

public abstract class ActivatableObject : MonoBehaviour {
    public abstract void Activate(ColorOwner colorOwner);
    public abstract void Deactivate(ColorOwner colorOwner);
}