namespace Deirin.Utilities {
    using UltEvents;
    using UnityEngine;

    public class GameEventListener_Float : MonoBehaviour {
        public GameEvent_Float gameEvent;
        public UltEvent<float> response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( float value ) {
            response.Invoke( value );
        }
    }
}