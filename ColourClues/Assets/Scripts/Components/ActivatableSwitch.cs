using UnityEngine;
public class ActivatableSwitch : ActivatableObject {

    [SerializeField] private GameObject activatableItem;
    [SerializeField] private bool defaultOn;

    private void Awake() {
        activatableItem?.SetActive(defaultOn);
    }

    public override void Activate(ColorOwner colorOwner) {
        activatableItem?.SetActive(!defaultOn);
    }

    public override void Deactivate(ColorOwner colorOwner) {
    }
}