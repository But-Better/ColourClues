using DefaultNamespace;
using Event;
using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObjects/Event/ColorClueEvent")]
public class ColorClueEvent : BaseGameEvent<ColorClue> {

    [SerializeField] private bool stateful = true;

    private ColorClue lastEvent;
    private int listenerCounter;

    private void OnEnable() {
        lastEvent = null;
    }

    public override void Raise(ColorClue value) {
        lastEvent = value;

        base.Raise(value);
    }

    public override void RegisterListener(BaseGameEventListener<ColorClue> listener) {
        base.RegisterListener(listener);

        if(stateful && lastEvent != null) {
            listener.OnEventRaised(lastEvent);
        }
    }
}