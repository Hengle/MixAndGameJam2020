namespace Deirin.Utilities {
    using UltEvents;
    using UnityEngine;

    public class GameEventListener_String : MonoBehaviour {
        public GameEvent_String gameEvent;
        public UltEvent<string> response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( string value ) {
            response.Invoke( value );
        }
    }
}