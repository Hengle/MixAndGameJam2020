    using UltEvents;
    using UnityEngine;

    public class GameEventListener_Card : MonoBehaviour {
        public GameEvent_Card gameEvent;
        public UltEvent<Card> response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( Card value ) {
            response.Invoke( value );
        }
    }