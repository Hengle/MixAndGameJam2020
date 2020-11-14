using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Game/GameEventNeedBar" )]
public class GameEvent_NeedBar : ScriptableObject {
    [SerializeField] private NeedBar value;
    public System.Action<NeedBar> OnInvoke;

    private List<GameEventListener_NeedBar> listeners = new List<GameEventListener_NeedBar>();

    public void Subscribe ( GameEventListener_NeedBar listener ) {
        listeners.Add( listener );
    }

    public void Unsubscribe ( GameEventListener_NeedBar listener ) {
        listeners.Remove( listener );
    }

    public void Invoke () {
        for ( int i = 0; i < listeners.Count; i++ ) {
            listeners[i].OnInvoke( value );
        }
    }

    public void Invoke ( NeedBar value ) {
        for ( int i = 0; i < listeners.Count; i++ ) {
            listeners[i].OnInvoke( value );
        }
        OnInvoke?.Invoke( value );
    }
}