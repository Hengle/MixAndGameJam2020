using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Game/GameEventCard" )]
public class GameEvent_Card : ScriptableObject {
    [SerializeField] private Card value;
    public System.Action<Card> OnInvoke;

    private List<GameEventListener_Card> listeners = new List<GameEventListener_Card>();

    public void Subscribe ( GameEventListener_Card listener ) {
        listeners.Add( listener );
    }

    public void Unsubscribe ( GameEventListener_Card listener ) {
        listeners.Remove( listener );
    }

    public void Invoke () {
        for ( int i = 0; i < listeners.Count; i++ ) {
            listeners[i].OnInvoke( value );
        }
    }

    public void Invoke ( Card value ) {
        for ( int i = 0; i < listeners.Count; i++ ) {
            listeners[i].OnInvoke( value );
        }
        OnInvoke?.Invoke( value );
    }
}