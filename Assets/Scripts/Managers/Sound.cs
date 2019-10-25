using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    [HideInInspector]
    public AudioSource source;

    public string name;

    [Range(0,1)]
    public float volume;
    [Range(.1f,3)]
    public float pitch;
    [Range(0,1)]
    public float dimension;

    public bool loop;
}
