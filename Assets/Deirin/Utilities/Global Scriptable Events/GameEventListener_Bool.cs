namespace Deirin.Utilities {
    using UltEvents;
    using UnityEngine;

    public class GameEventListener_Bool : MonoBehaviour {
        public GameEvent_Bool gameEvent;
        public UltEvent<bool> response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( bool value ) {
            response.Invoke( value );
        }
    }
}