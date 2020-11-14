using System.Collections.Generic;
using UltEvents;
using UnityEngine;

public class NeedBar : MonoBehaviour {
    [Header("Refs")]
    public SC_NeedBar needData;

    [Header("Params")]
    public bool locked;
    public float currentValue;

    [Header("Events")]
    public UltEvent<float> OnValueChangePercent;
    public UltEvent<List<SC_Card>> OnUnlock;
    public UltEvent OnBarEmpty;

    private void Start () {
        currentValue = needData.startValue;
        OnValueChangePercent.Invoke( currentValue / needData.maxValue );
    }

    public void Unlock () {
        locked = false;
        OnUnlock.Invoke( needData.unlockedCards );
    }

    public void Add ( float value ) {
        currentValue += value;
        float percent = Mathf.Clamp01( currentValue / needData.maxValue );
        OnValueChangePercent.Invoke( percent );

        if ( percent <= 0 ) {
            OnBarEmpty.Invoke();
        }
    }

    public void CardEffectValueChangeHanlder ( SC_NeedBar needData, float amount ) {
        if ( needData == this.needData ) {
            Add( amount );
        }
    }

    public void WeightChangeHandler ( float value ) {
        if ( !locked )
            return;

        if ( value >= needData.unlockWeight )
            Unlock();
    }
}