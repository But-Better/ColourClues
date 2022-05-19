using UnityEngine;
using UnityEngine.Events;

namespace Event {
    public abstract class BaseGameEventListener : MonoBehaviour {
        public BaseGameEvent Event;
        public UnityEvent Response;

        private void OnEnable() {
            Event.RegisterListener(this);
        }

        private void OnDisable() {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised() {
            Response.Invoke();
        }
    }

    public abstract class BaseGameEventListener<T1> : MonoBehaviour {
        public BaseGameEvent<T1> Event;
        public UnityEvent<T1> Response;

        private void OnEnable() {
            Event.RegisterListener(this);
        }

        private void OnDisable() {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised(T1 value) {
            Response.Invoke(value);
        }
    }

    public abstract class BaseGameEventListener<T1, T2> : MonoBehaviour {
        public BaseGameEvent<T1, T2> Event;
        public UnityEvent<T1, T2> Response;

        private void OnEnable() {
            Event.RegisterListener(this);
        }

        private void OnDisable() {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised(T1 value1, T2 value2) {
            Response.Invoke(value1, value2);
        }
    }

    public abstract class BaseGameEventListener<T1, T2, T3> : MonoBehaviour {
        public BaseGameEvent<T1, T2, T3> Event;
        public UnityEvent<T1, T2, T3> Response;

        private void OnEnable() {
            Event.RegisterListener(this);
        }

        private void OnDisable() {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised(T1 value1, T2 value2, T3 value3) {
            Response.Invoke(value1, value2, value3);
        }
    }
}