namespace Deirin.Utilities {
    using UltEvents;
    using UnityEngine;

    public class IntVariableGetter : MonoBehaviour {
        public IntVariable variable;

        public UltEvent<int> OnValueChange;
        public UltEvent<int> OnGet;

        private void OnEnable () {
            variable.OnValueChanged += ValueChangeHandler;
        }

        private void OnDisable () {
            variable.OnValueChanged -= ValueChangeHandler;
        }

        private void ValueChangeHandler ( int obj ) {
            OnValueChange.Invoke( obj );
        }

        public int Get () {
            OnGet.Invoke( variable.Value );
            return variable.Value;
        }

        public void InvokeGet () {
            OnGet.Invoke( variable.Value );
        }
    }
}