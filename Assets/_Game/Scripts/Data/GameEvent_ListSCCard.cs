using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Game/ListCardsEvent" )]
public class GameEvent_ListSCCard : ScriptableObject {
    [SerializeField] private List<SC_Card> value;
    public System.Action<List<SC_Card>> OnInvoke;

    private List<GameEventListener_ListSCCard> listeners = new List<GameEventListener_ListSCCard>();

    public void Subscribe ( GameEventListener_ListSCCard listener ) {
        listeners.Add( listener );
    }

    public void Unsubscribe ( GameEventListener_ListSCCard listener ) {
        listeners.Remove( listener );
    }

    public void Invoke () {
        for ( int i = 0; i < listeners.Count; i++ ) {
            listeners[i].OnInvoke( value );
        }
    }

    public void Invoke ( List<SC_Card> value ) {
        for ( int i = 0; i < listeners.Count; i++ ) {
            listeners[i].OnInvoke( value );
        }
        OnInvoke?.Invoke( value );
    }
}