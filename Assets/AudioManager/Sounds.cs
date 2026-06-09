using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip clip;
    public float volume = 1f;

    [Header("Pitch Settings")]
    public bool useRandomPitch = false;
    public float minPitch = 1f;
    public float maxPitch = 1f;

    public bool loop;
    [HideInInspector]
    public AudioSource source;
}