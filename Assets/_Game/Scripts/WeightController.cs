using UltEvents;
using UnityEngine;

public class WeightController : MonoBehaviour {
    public FloatVariable weight;
    public UltEvent<float> OnValueChanged;

    private void OnEnable () => weight.OnValueChanged += OnValueChanged.Invoke;

    private void OnDisable () => weight.OnValueChanged -= OnValueChanged.Invoke;

    public void Add ( float value ) => weight.Value += value;
    public void Add(Card card) => weight.Value += card.cardData.weight;
}