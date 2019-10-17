using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Experimental.UIElements;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    string backgroundMusic_Name;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
            
        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.name = sound.name;
        }
    }

    private void Start()
    {
        backgroundMusic_Name = "bgm-urss";
        Play(backgroundMusic_Name);
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    public void Play(string audio_name)
    {
        Sound sound = Array.Find(sounds, s => s.name == audio_name);
        if (sound == null)
            return;
        sound.source.Play();
    }

    bool isMuted = false;
    public void Mute() {
        isMuted = (!isMuted)?true:false;
        foreach (Sound s in sounds)
            s.source.mute = isMuted;
    }

    public void SetBackgroundMusic(float n_volume)
    {        
        Array.Find(sounds, sound => sound.name.Equals(backgroundMusic_Name)).source.volume = n_volume;
    }

    public void SetSFXMusic(float n_volume)
    {
        foreach (Sound sound in sounds)
        {
            if (sound.name.StartsWith("sfx"))
                sound.source.volume = n_volume;
        }
    }
}
