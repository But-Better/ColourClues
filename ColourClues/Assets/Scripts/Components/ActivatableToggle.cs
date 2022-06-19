using UnityEngine;
public class ActivatableToggle : ActivatableObject {

    [SerializeField] private GameObject defaultOnItem;
    [SerializeField] private GameObject defaultOffItem;

    private void Awake() {
        defaultOffItem?.gameObject.SetActive(false);
        defaultOnItem?.gameObject.SetActive(true);
    }

    public override void Activate() {
        defaultOffItem?.gameObject.SetActive(true);
        defaultOnItem?.gameObject.SetActive(false);
    }

    public override void Deactivate() {
        defaultOffItem?.gameObject.SetActive(false);
        defaultOnItem?.gameObject.SetActive(true);
    }
}