using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public string name;
    public AudioClip clip;

    [Range(0f,2f)]
    public float volume = 1.0f;
    [Range(0.1f,3f)]
    public float pitch;

    public bool loop;
    public float soundLength;
    public AudioSource source;
    public AudioMixerGroup mixerGroup;

}
