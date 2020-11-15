using DG.Tweening;
using UltEvents;
using UnityEngine;
using UnityEngine.UI;

public class Fatty : MonoBehaviour {
    [Header("Params")]
    public FatState[] fatStates;
    public float scaleMultiplier = .1f;

    [Header("Refs")]
    public Image image;

    [Header("Events")]
    public UltEvent OnFatStateChange;

    private FatState currentFatState;
    private float weight;

    private void Start () {
        currentFatState = fatStates[0];
    }

    public void WeightChangeHandler ( float value ) {
        weight = value;
        UpdateScale();

        foreach ( var fatState in fatStates ) {
            if ( weight >= fatState.unlockWeight ) {
                ChangeFatState( fatState );
                return;
            }
        }
    }

    private void ChangeFatState ( FatState fatState ) {
        currentFatState = fatState;
        image.sprite = currentFatState.sprite;
        OnFatStateChange.Invoke();
    }

    private void UpdateScale () {
        float targetScale = 1f + weight * scaleMultiplier;
        transform.DOScale( targetScale, .3f ).SetEase( Ease.OutBounce ).Play();
    }

    [System.Serializable]
    public class FatState {
        public float unlockWeight;
        public Sprite sprite;
    }
}