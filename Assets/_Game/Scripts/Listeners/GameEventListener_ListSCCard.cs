using System.Collections.Generic;
using UltEvents;
    using UnityEngine;

    public class GameEventListener_ListSCCard : MonoBehaviour {
        public GameEvent_ListSCCard gameEvent;
        public UltEvent<List<SC_Card>> response;

        private void OnEnable () {
            gameEvent.Subscribe( this );
        }

        private void OnDisable () {
            gameEvent.Unsubscribe( this );
        }

        public void OnInvoke ( List<SC_Card> value ) {
            response.Invoke( value );
        }
    }