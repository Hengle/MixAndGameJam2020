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
    public Slider slider;

    [Header("Params")]
    [ReadOnly] public bool locked;
    public float fillSpeed = 5f;

    [Header("Events")]
    public UltEvent<List<SC_Card>> OnUnlock;
    public UltEvent OnLock;
    public UltEvent OnBarEmpty;
    public UltEvent OnWarningStart;
    public UltEvent OnWarningEnd;

    private float _currentValue;
    private float currentValue { get => _currentValue; set => _currentValue = Mathf.Clamp( value, 0f, needData.maxValue ); }

    private void Start () {
        fillImage.color = needData.color;
        slider.value = 0f;

        if ( needData.startsLocked )
            Lock();
        else
            GoToStartValue();
    }

    private void GoToStartValue () {
        currentValue = needData.startValue;
        UpdateUI();
    }

    public void Unlock () {
        locked = false;
        OnUnlock.Invoke( needData.unlockedCards );
        GoToStartValue();
    }

    public void Lock () {
        locked = true;
        OnLock.Invoke();
    }

    public void Add ( float value ) {
        currentValue += value;
        UpdateUI();

        float percent = Mathf.Clamp01( currentValue / needData.maxValue );

        if ( percent == 0 ) {
            OnBarEmpty.Invoke();
        }
        else if ( percent <= needData.warningTresholdPercent ) {
            OnWarningStart.Invoke();
        }
        else
            OnWarningEnd.Invoke();
    }

    public void UpdateUI () {
        float percent = currentValue / needData.maxValue;
        slider.DOValue( percent, fillSpeed ).SetSpeedBased().Play();
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

    public void BarUnlockHandler ( NeedBar needBar ) {
        if ( needBar != this ) {
            currentValue = Mathf.Lerp( currentValue, needData.startValue, needData.softResetLerpPercent );
            UpdateUI();
        }
    }
}