using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] _sounds;

    [SerializeField] private AudioMixerGroup _mainMixer;
    public static float _volume
    {
        get => PlayerPrefs.GetFloat("Volume", 0);
        set => PlayerPrefs.SetFloat("Volume", value);
    }
    public static float _vibration
    {
        get => PlayerPrefs.GetFloat("Vibration", 0);
        set => PlayerPrefs.SetFloat("Vibration", value);
    }

    private void OnEnable()
    {
        foreach(Sound sound in _sounds)
        {
            sound._source = gameObject.AddComponent<AudioSource>();
            sound._source.clip = sound._clip;
            sound._source.volume = sound._volume;
            sound._source.pitch = sound._pitch;
            sound._source.outputAudioMixerGroup = _mainMixer;
            sound._source.loop = sound._loop;
        }
    }

    private void Start()
    {
        Play("BackgroundMusic");
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

    public void SetVolume(float volume)
    {
        _mainMixer.audioMixer.SetFloat("Volume", volume);
        _volume = volume;
    }

    public void SetVibration(float vibration)
    {
        _vibration = vibration;
    }
}
