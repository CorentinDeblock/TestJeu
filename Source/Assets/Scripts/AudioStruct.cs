using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioStruct
{
    public AudioClip clip;
    [Range(0.0f,1.0f)]
    public float volume = 80.0f;
    [Range(0.0f, 3.0f)]
    public float pitch = 1.0f;

    public string category;

    public string title;
    [HideInInspector]
    public AudioSource source;

    public bool loop = false;
}
