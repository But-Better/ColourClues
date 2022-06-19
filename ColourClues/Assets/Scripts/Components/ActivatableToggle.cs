using UnityEngine;
public class ActivatableToggle : ActivatableObject {

    [SerializeField] private GameObject defaultOnItem;
    [SerializeField] private GameObject defaultOffItem;

    private void Awake() {
        defaultOffItem?.SetActive(false);
        defaultOnItem?.SetActive(true);
    }

    public override void Activate(ColorOwner colorOwner) {
        defaultOffItem?.SetActive(true);
        defaultOnItem?.SetActive(false);
    }

    public override void Deactivate(ColorOwner colorOwner) {
        defaultOffItem?.SetActive(false);
        defaultOnItem?.SetActive(true);
    }
}