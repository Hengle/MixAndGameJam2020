    using UltEvents;
    using UnityEngine;

    public class GameEventListener_NeedBar : MonoBehaviour {
        public GameEvent_NeedBar gameEvent;
        public UltEvent<NeedBar> response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( NeedBar value ) {
            response.Invoke( value );
        }
    }