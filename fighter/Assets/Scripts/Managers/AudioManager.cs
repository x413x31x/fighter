using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] _sounds;
    public static AudioManager _instance;

    private void Awake()
    {        
        foreach(Sound sound in _sounds)
        {
            sound._source = gameObject.AddComponent<AudioSource>();
            sound._source.clip = sound._clip;
            sound._source.volume = sound._volume;
            sound._source.pitch = sound._pitch;
            sound._source.loop = sound._loop;
        }
    }

    public void Play(string name)
    {
        Sound sound = Array.Find(_sounds, sound => sound._name == name);
        if(sound == null)
        {
            return;
        }
        sound._source.Play();
    }

    public void Stop(string name)
    {
        Sound sound = Array.Find(_sounds, sound => sound._name == name);
        if (sound == null)
        {
            return;
        }
        sound._source.Stop();
    }
}
