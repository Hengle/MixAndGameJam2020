namespace Deirin.Utilities {
    using UltEvents;
    using UnityEngine;

    public class GameEventListener : MonoBehaviour {
        public GameEvent gameEvent;
        public UltEvent response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke () {
            response.Invoke();
        }
    }
}