using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class Music
{
    public int number;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public bool playOnAwake = true;
    [HideInInspector]
    public bool loop = true;
    [HideInInspector]
    public AudioSource source;
}
