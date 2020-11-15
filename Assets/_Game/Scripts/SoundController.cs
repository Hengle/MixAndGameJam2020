using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour {
    public AudioMixer mixer;

    private bool music, fx;

    public void ToggleMusic () {
        music = !music;
        mixer.SetFloat( "Music", music ? -80f : 0f );
    }

    public void ToggleFX () {
        fx = !fx;
        mixer.SetFloat( "FX", fx ? -80f : 0f );
    }
}