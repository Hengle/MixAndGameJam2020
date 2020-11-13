namespace Deirin.Utilities {
    using UltEvents;
    using UnityEngine;

    public class BoolVariableGetter : MonoBehaviour {
        public BoolVariable variable;

        public UltEvent<bool> OnValueChange;
        public UltEvent<bool> OnGet;

        private void OnEnable () {
            variable.OnValueChanged += ValueChangeHandler;
        }

        private void OnDisable () {
            variable.OnValueChanged -= ValueChangeHandler;
        }

        private void ValueChangeHandler ( bool obj ) {
            OnValueChange.Invoke( obj );
        }

        public bool Get () {
            OnGet.Invoke( variable.Value );
            return variable.Value;
        }

        public void InvokeGet () {
            OnGet.Invoke( variable.Value );
        }
    }
}