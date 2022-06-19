using UnityEngine;
public class ActivatableToggle : ActivatableObject {

    [SerializeField] private GameObject defaultOnItem;
    [SerializeField] private GameObject defaultOffItem;

    private void Awake() {
        defaultOffItem?.SetActive(false);
        defaultOnItem?.SetActive(true);
    }

    public override void Activate() {
        defaultOffItem?.SetActive(true);
        defaultOnItem?.SetActive(false);
    }

    public override void Deactivate() {
        defaultOffItem?.SetActive(false);
        defaultOnItem?.SetActive(true);
    }
}