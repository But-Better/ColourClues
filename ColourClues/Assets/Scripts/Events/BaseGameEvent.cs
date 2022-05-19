using System.Collections.Generic;
using UnityEngine;

namespace Event {
    public abstract class RootGameEvent : ScriptableObject {
#if UNITY_EDITOR
        [TextArea] public string DeveloperDescription = "";
#endif
    }

    [CreateAssetMenu(menuName = "ScriptableObjects/Event/BaseGameEvent")]
    public sealed class BaseGameEvent : RootGameEvent {
        private readonly List<BaseGameEventListener> eventListeners = new List<BaseGameEventListener>();


        public void Raise() {
            for(var i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }

        public void RegisterListener(BaseGameEventListener listener) {
            if(!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(BaseGameEventListener listener) {
            if(eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }

    public abstract class BaseGameEvent<T1> : RootGameEvent {
        private readonly List<BaseGameEventListener<T1>> eventListeners = new List<BaseGameEventListener<T1>>();


        public void Raise(T1 value) {
            for(var i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(value);
        }

        public void RegisterListener(BaseGameEventListener<T1> listener) {
            if(!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(BaseGameEventListener<T1> listener) {
            if(eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }

    public abstract class BaseGameEvent<T1, T2> : RootGameEvent {
        private readonly List<BaseGameEventListener<T1, T2>> eventListeners = new List<BaseGameEventListener<T1, T2>>();

        public void Raise(T1 value1, T2 value2) {
            for(var i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(value1, value2);
        }

        public void RegisterListener(BaseGameEventListener<T1, T2> listener) {
            if(!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(BaseGameEventListener<T1, T2> listener) {
            if(eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }

    public abstract class BaseGameEvent<T1, T2, T3> : RootGameEvent {
        private readonly List<BaseGameEventListener<T1, T2, T3>> eventListeners = new List<BaseGameEventListener<T1, T2, T3>>();

        public void Raise(T1 value1, T2 value2, T3 value3) {
            for(var i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(value1, value2, value3);
        }

        public void RegisterListener(BaseGameEventListener<T1, T2, T3> listener) {
            if(!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public void UnregisterListener(BaseGameEventListener<T1, T2, T3> listener) {
            if(eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}