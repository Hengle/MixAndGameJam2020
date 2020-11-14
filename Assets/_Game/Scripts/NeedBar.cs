using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UltEvents;
using UnityEngine;
using UnityEngine.UI;

public class NeedBar : MonoBehaviour {
    [Header("Refs")]
    public SC_NeedBar needData;
    public Image fillImage;

    [Header("Params")]
    [ReadOnly] public bool locked;
    [ReadOnly] public float currentValue;
    public float fillSpeed = 5f;

    [Header("Events")]
    public UltEvent<float> OnValueChangePercent;
    public UltEvent<List<SC_Card>> OnUnlock;
    public UltEvent OnLock;
    public UltEvent OnBarEmpty;

    private void Start () {
        fillImage.color = needData.color;

        if ( needData.startsLocked )
            Lock();

        currentValue = needData.startValue;
        OnValueChangePercent.Invoke( currentValue / needData.maxValue );
    }

    public void Unlock () {
        locked = false;
        OnUnlock.Invoke( needData.unlockedCards );
    }

    public void Lock () {
        locked = true;
        OnLock.Invoke();
    }

    public void Add ( float value ) {
        currentValue += value;
        float percent = Mathf.Clamp01( currentValue / needData.maxValue );
        OnValueChangePercent.Invoke( percent );

        fillImage.DOFillAmount( percent, fillSpeed ).SetSpeedBased();

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