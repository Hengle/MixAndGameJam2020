namespace Deirin.Utilities {
    using UltEvents;
    using UnityEngine;

    public class FromFloatToString : MonoBehaviour {
        public UltEvent<string> OnConversion;

        public void Convert ( float value ) => OnConversion.Invoke( value.ToString() );
    }
}