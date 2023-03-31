using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector] public AudioSource _source;
    public string _name;
    public AudioClip _clip;

    [Range(0f, 1f)] public float _volume;
    [Range(0.1f, 3f)] public float _pitch;
    public bool _loop;

}
