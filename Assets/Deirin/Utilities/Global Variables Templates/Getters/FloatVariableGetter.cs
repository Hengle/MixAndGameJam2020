namespace Deirin.Utilities {
    using UltEvents;
    using UnityEngine;

    public class FloatVariableGetter : MonoBehaviour {
        public FloatVariable variable;

        public UltEvent<float> OnValueChange;
        public UltEvent<float> OnGet;

        private void OnEnable () {
            variable.OnValueChanged += ValueChangeHandler;
        }

        private void OnDisable () {
            variable.OnValueChanged -= ValueChangeHandler;
        }

        private void ValueChangeHandler ( float obj ) {
            OnValueChange.Invoke( obj );
        }

        public float Get () {
            OnGet.Invoke( variable.Value );
            return variable.Value;
        }

        public void InvokeGet () {
            OnGet.Invoke( variable.Value );
        }
    }
}