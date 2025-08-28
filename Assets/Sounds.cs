using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Sounds 
{
    public string name;
    public AudioClip clip;

    public float volume;
    public bool loop;
    public AudioSource source;
}
