using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Game/Effect Event")]
public class GameEvent_CardEffect : ScriptableObject
{
    public bool useNeedType;
    public bool useFloatValue;

    [SerializeField, Space, ShowIf("useNeedType")] private SC_NeedBar needType;
    [SerializeField, ShowIf("useFloatValue")] private float floatValue;

    public System.Action<SC_NeedBar, float> OnInvoke;


    private List<GameEventListener_CardEffect> listeners = new List<GameEventListener_CardEffect>();

    public void Subscribe(GameEventListener_CardEffect listener)
    {
        listeners.Add(listener);
    }

    public void Unsubscribe(GameEventListener_CardEffect listener)
    {
        listeners.Remove(listener);
    }

    public void Invoke()
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnInvoke(needType, floatValue);
        }
    }

    public void Invoke(SC_NeedBar needType, float floatValue)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnInvoke(needType, floatValue);
        }
        OnInvoke?.Invoke(needType, floatValue);
    }
}