﻿using UltEvents;
using UnityEngine;

public class GameEventListener_CardEffect : MonoBehaviour
{
    public GameEvent_CardEffect gameEvent;
    public UltEvent<SC_NeedType, float> response;

    private void OnEnable()
    {
        gameEvent.Subscribe(this);
    }

    private void OnDisable()
    {
        gameEvent.Unsubscribe(this);
    }

    public void OnInvoke(SC_NeedType needType, float floatValue)
    {
        response.Invoke(needType, floatValue);
    }
}