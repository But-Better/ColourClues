using Event;
using UnityEngine;

namespace Components {
    [RequireComponent(typeof(ColorOwner))]
    public class PlayerRegister : MonoBehaviour {

        [SerializeField] private BaseGameEvent<ColorOwner> playerSpawnedEvent;
        [SerializeField] private BaseGameEvent<ColorOwner> playerDespawnedEvent;

        private void Start() {
            var colorOwner = GetComponent<ColorOwner>();
            playerSpawnedEvent?.Raise(colorOwner);
        }

        private void OnDestroy() {
            var colorOwner = GetComponent<ColorOwner>();
            playerDespawnedEvent?.Raise(colorOwner);
        }
    }
}